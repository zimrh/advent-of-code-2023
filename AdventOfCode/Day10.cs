using AdventOfCode.Common;
using AdventOfCode.Enums;
using AdventOfCode.Models;

namespace AdventOfCode;

public class Day10 : AdventDay
{
    public int Run(TestType testType, Part part)
    {
        var pipeMap = GetPipeMap(testType, part);
        return part == Part.One ?
            GetPipePath(pipeMap).Count / 2 :
            RunPartTwo(pipeMap);
    }

    public static int RunPartTwo(PipeMap pipeMap)
    {
        pipeMap.Map[pipeMap.StartingPoint.ToString()] = pipeMap.ReplaceStartingCharacter(pipeMap.StartingPoint);

        var path = GetPipePath(pipeMap);

        var pointsInsideShape = new HashSet<Coordinate>();
        var bottom = pipeMap.GetBottom();
        var right = pipeMap.GetRight();

        for (int y = 0; y <= bottom; y++)
        {
            var insideShape = false;
            var lastAngleSymbol = ' ';
            for (int x = 0; x <= right; x++)
            {
                var coord = new Coordinate(x, y);
                if(!path.Contains(coord))
                {
                    if (insideShape)
                    {
                        pointsInsideShape.Add(coord);
                    }
                    continue;
                }

                var currentSymbol = pipeMap.GetPipePart(coord).Symbol;

                if (currentSymbol == '|')
                {
                    insideShape = !insideShape;
                    continue;
                }

                if (currentSymbol == 'L' || currentSymbol == 'F')
                {
                    lastAngleSymbol = currentSymbol;
                    continue;
                }

                if (currentSymbol == '-')
                {
                    continue;
                }

                if ((lastAngleSymbol == 'L' && currentSymbol == '7') ||
                    (lastAngleSymbol == 'F' && currentSymbol == 'J'))
                {
                    insideShape = !insideShape;
                }

                lastAngleSymbol = ' ';
            }
        }
        return pointsInsideShape.Count;
    }

    public static HashSet<Coordinate> GetPipePath(PipeMap pipeMap)
    {
        var path = new HashSet<Coordinate>()
        {
            new (pipeMap.StartingPoint),
            new (pipeMap.StartingPoint, pipeMap.GetValidStartDirections(pipeMap.StartingPoint).First())
        };

        var finished = false;
        do
        {
            var pipePart = pipeMap.GetPipePart(path.Last());
            foreach(var direction in pipePart.GetAvailableDirections())
            {
                var newCoord = new Coordinate(path.Last(), direction);
                if (pipeMap.StartingPoint.Equals(newCoord) && !(path.Count < 3))
                {
                    finished = true;
                }
                if (path.Contains(newCoord))
                {
                    continue;
                }
                path.Add(newCoord);
                break;
            }
        } while (!finished);
        return path;
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
