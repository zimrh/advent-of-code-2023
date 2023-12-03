using System.Text;
using AdventOfCode.Common;
using AdventOfCode.Enums;
using AdventOfCode.Models;

namespace AdventOfCode;

public class Day3 : AdventDay
{
    public int Run(TestType testType, Part part)
    {
        return 0;
    }

    public Schematic GetSchematic(TestType testType, Part part)
    {
        var schematic = new Schematic();
        int y = 0;
        var number = new StringBuilder();
        var coords = new List<string>();
        foreach(var line in ReadFromFile(testType, part))
        {
            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] == '.')
                {
                    schematic.SchematicNumbers.Add(coords.First(), new SchematicNumber{

                    });
                    number.Clear();
                    continue;
                }
                schematic.Plan.Add(Coordinate.ToRaw(x, y), line[x]);
                if (!line[x].IsNumber()) {
                    schematic.Symbols.Add(Coordinate.ToRaw(x, y));
                    continue;
                }
                coords.Add(Coordinate.ToRaw(x, y));
                number.Append(line[x]);
            }
            y++;
        }
        return schematic;
    }
}
