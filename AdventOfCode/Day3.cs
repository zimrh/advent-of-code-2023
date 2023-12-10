using System.Text;
using AdventOfCode.Common;
using AdventOfCode.Enums;
using AdventOfCode.Models;

namespace AdventOfCode;

public class Day3 : AdventDay
{
    public int Run(TestType testType, Part part)
    {
        var schematic = GetSchematic(testType, part);
        return Part.One == part ?
            PartOne(schematic) :
            PartTwo(schematic);
    }

    public int PartTwo(Schematic schematic)
    {
        var totals = 0;
        foreach(var symbol in schematic.Symbols)
        {
            if (symbol.Value != '*')
            {
                continue;
            }

            var gearValues = new Dictionary<string, int>();

            var gearCoordinates = new Coordinate(symbol.Key);
            foreach(var direction in (Direction[]) Enum.GetValues(typeof(Direction)))
            {
                var newCoord = new Coordinate(gearCoordinates, direction);
                var charAtCoord = schematic.GetCoordinate(newCoord);
                if (charAtCoord == '.' || !charAtCoord.IsNumber())
                {
                    continue;
                }
                foreach(var number in schematic.SchematicNumbers)
                {
                    if(number.Coordinates.Contains(newCoord.ToString()))
                    {
                        var numbersFirstCoord = number.Coordinates.First();
                        if(!gearValues.ContainsKey(numbersFirstCoord))
                        {
                            gearValues.Add(numbersFirstCoord, number.Value);
                        }
                    }
                }
            }
            if (gearValues.Count != 2)
            {
                continue;
            }
            totals += gearValues.First().Value * gearValues.Last().Value;
        }
        return totals;

    }

    public int PartOne(Schematic schematic)
    {
        var parts = new Dictionary<string, int>();
        foreach(var symbol in schematic.Symbols)
        {
            var symbolCoord = new Coordinate(symbol.Key);
            foreach(var direction in (Direction[]) Enum.GetValues(typeof(Direction)))
            {
                var newCoord = new Coordinate(symbolCoord, direction);
                var charAtCoord = schematic.GetCoordinate(newCoord);
                if (charAtCoord == '.' || !charAtCoord.IsNumber())
                {
                    continue;
                }
                foreach(var number in schematic.SchematicNumbers)
                {
                    if(number.Coordinates.Contains(newCoord.ToString()))
                    {
                        var numbersFirstCoord = number.Coordinates.First();
                        if(!parts.ContainsKey(numbersFirstCoord))
                        {
                            parts.Add(numbersFirstCoord, number.Value);
                        }
                    }
                }
            }
        }
        return parts.Sum(p => p.Value);
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
                if (number.Length > 0 && !line[x].IsNumber())
                {
                    schematic.SchematicNumbers.Add(
                        new SchematicNumber(coords, int.Parse(number.ToString())));
                    coords.Clear();
                    number.Clear();
                }
                if (line[x] == '.')
                {
                    continue;
                }
                schematic.Map.Add(Coordinate.ToRaw(x, y), line[x]);
                if (!line[x].IsNumber()) {
                    schematic.Symbols.Add(Coordinate.ToRaw(x, y), line[x]);
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
