namespace AdventOfCode.Models;

public class SchematicNumber
{
    public SchematicNumber(List<string> coords, int value)
    {
        Coordinates = coords.ToHashSet();
        Value = value;
    }
    public HashSet<string> Coordinates = [];
    public int Value;
}
