using AdventOfCode.Common;
using AdventOfCode.Enums;
using AdventOfCode.Models;

namespace AdventOfCode;

public class Day10 : AdventDay
{

    public int Run(TestType testType, Part part)
    {
        var pipeMap = GetPipeMap(testType, part);
        return RunPartOne(pipeMap);
    }

    public int RunPartOne(PipeMap pipeMap)
    {
        var paths = new List<HashSet<Coordinate>>();
        foreach(var direction in pipeMap.GetValidStartDirections(pipeMap.StartingPoint))
        {
            paths.Add([
                new (pipeMap.StartingPoint),
                new (pipeMap.StartingPoint, direction)
            ]);
        }
        do
        {
            foreach(var path in paths)
            {
                var pipePart = pipeMap.GetPipePart(path.Last());
                foreach(var direction in pipePart.GetAvailableDirections())
                {
                    var newCoord = new Coordinate(path.Last(), direction);
                    if (path.Contains(newCoord))
                    {
                        continue;
                    }
                    path.Add(newCoord);
                    break;
                }
            }
        } while (!paths[0].Last().Equals(paths[1].Last()));
        return paths[0].Count - 1;
    }


    public PipeMap GetPipeMap(TestType testType, Part part)
    {
        var pipeMap = new PipeMap();
        var y = 0;
        foreach(var line in ReadFromFile(testType, part))
        {
            for (int x = 0; x < line.Length; x++)
            {
                if(line[x] == 'S')
                {
                    pipeMap.StartingPoint = new Coordinate(x, y);
                }
                pipeMap.Map.Add(Coordinate.ToRaw(x, y), line[x]);
            }
            y++;
        }
        return pipeMap;
    }
}
