using AdventOfCode.Common;
using AdventOfCode.Enums;

namespace AdventOfCode;

public class Day11 : AdventDay
{

    public long Run(TestType testType, Part part)
    {
        var galaxyMap = LoadGalaxyMap(testType, part);
        galaxyMap = ExpandGalaxyMap(galaxyMap, part == Part.One ? 1 : 1000000);
        return getSumOfShortestDistances(galaxyMap);
    }

    private long getSumOfShortestDistances(GalaxyMap galaxyMap)
    {
        long sumOfDistance = 0;
        foreach(var firstGalaxy in galaxyMap.Map.Keys)
        {
            var lengths = new List<long>();
            foreach(var secondGalaxy in galaxyMap.Map.Keys)
            {
                sumOfDistance += LongCoordinate.GetDistance(firstGalaxy, secondGalaxy);
            }
        }
        return sumOfDistance / 2;
    }

    public static GalaxyMap ExpandGalaxyMap(GalaxyMap galaxyMap, int expansion)
    {
        var newColumnGalaxyMap = new GalaxyMap();
        var rightMostGalaxy = galaxyMap.GetRight();
        long expansionAmount = 0;
        for (int x = 0; x <= rightMostGalaxy; x++)
        {
            var galaxiesInColumn = galaxyMap.GetGalaxiesInColumn(x);

            expansionAmount += (galaxiesInColumn.Count == 0) ? expansion : 0;

            foreach(var galaxy in galaxiesInColumn)
            {
                var newCoord = new LongCoordinate(galaxy.X + expansionAmount, galaxy.Y);
                newColumnGalaxyMap.Map.Add(newCoord.ToString(), '#');
            }
        }
        var finalGalaxy = new GalaxyMap();
        var bottomMostGalaxy = newColumnGalaxyMap.GetBottom();
        expansionAmount = 0;
        for (int y = 0; y <= bottomMostGalaxy; y++)
        {
            var galaxiesInRow = newColumnGalaxyMap.GetGalaxiesInRow(y);

            expansionAmount += (galaxiesInRow.Count == 0) ? 1 : 0;

            foreach(var galaxy in galaxiesInRow)
            {
                var newCoord = new LongCoordinate(galaxy.X, galaxy.Y + expansionAmount);
                finalGalaxy.Map.Add(newCoord.ToString(), '#');
            }
        }
        return finalGalaxy;
    }

    public GalaxyMap LoadGalaxyMap(TestType testType, Part part)
    {
        var galaxyMap = new GalaxyMap();
        var y = 0;
        foreach(var line in ReadFromFile(testType, part))
        {
            for (int x = 0; x < line.Length; x++)
            {
                if (line[x]=='.')
                {
                    continue;
                }
                galaxyMap.Map.Add(new LongCoordinate(x, y).ToString(), line[x]);
            }
            y++;
        }
        return galaxyMap;
    }
}
