using System.Text;
using AdventOfCode.Common;
using AdventOfCode.Enums;
using AdventOfCode.Models;

namespace AdventOfCode;

public class Day5 : AdventDay
{
    public int Run(TestType testType, Part part)
    {
        var maps = new List<GardenMap>();
        
        var condensedMap = new GardenMap()
        {
            Name = "seed-to-location"
        };
        var seeds = new List<int>();
        var mapName = string.Empty;
        var rawMapping = new List<string>();

        foreach (var line in ReadFromFile(testType, part))
        {
            if (line.StartsWith("seeds:"))
            {
                seeds = line
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)[1]
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList();
                continue;
            }

            if (string.IsNullOrWhiteSpace(line))
            {
                if (string.IsNullOrWhiteSpace(mapName))
                {
                    continue;
                }

                maps.Add(new GardenMap{
                    Name = mapName,
                    Rules = rawMapping.Select(m => new GardenMapRule(m)).ToList()
                });

                rawMapping.Clear();
                mapName = string.Empty;
                continue;
            }

            if (line.EndsWith("map:"))
            {
                mapName = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                continue;
            }

            rawMapping.Add(line);
        }

        maps.Add(new GardenMap{
            Name = mapName,
            Rules = rawMapping.Select(m => new GardenMapRule(m)).ToList()
        });
        
        foreach(var map in maps)
        {
            condensedMap = IntegrateMap(condensedMap, map);
            OutputMap(condensedMap);
        }

        return 0;
    }

    public void OutputMap(GardenMap gardenMap)
    {
        Console.WriteLine(gardenMap.Name);
        foreach(var rule in gardenMap.Rules.OrderBy(r => r.SourceStart))
        {
            Console.WriteLine($"{rule.SourceStart | rule.DestinationStart | rule.Diff}");
            Console.WriteLine($"{rule.SourceEnd | rule.DestinationEnd | rule.Diff}");
            Console.WriteLine("====================================================");
        }
    }

    public GardenMap IntegrateMap(GardenMap condensedMap, GardenMap map)
    {
        var newMap = new GardenMap();

        foreach(var rule in map.Rules)
        {
            var overlaps = false;
            foreach(var condensedRule in condensedMap.Rules)
            {
                // not overlapping this rule, next...
                if (rule.DestinationStart > rule.SourceEnd || rule.DestinationEnd < rule.SourceStart)
                {
                    continue;
                }
            }
            if(!overlaps)
            {
                newMap.Rules.Add(rule);
            }
        }

        return newMap;
    }
}
