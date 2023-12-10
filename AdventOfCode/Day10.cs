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
        var paths = new List<List<Coordinate>>();
        foreach(var direction in pipeMap.GetValidDirections(pipeMap.StartingPoint))
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
                foreach(var direction in pipeMap.GetValidDirections(path.Last()))
                {
                    var newCoord = new Coordinate(path.Last(), direction);
                    if (path.Last() == newCoord)
                    {
                        continue;
                    }
                    path.Add(newCoord);
                }
            }
        } while (paths[0].Last() == paths[1].Last());
        return 0;
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
