namespace AdventOfCode.Models;

public class Schematic : CharMap
{
    public Dictionary<string, char> Symbols = [];
    public List<SchematicNumber> SchematicNumbers = [];
}
