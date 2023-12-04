namespace AdventOfCode.Models;

public class Schematic
{
    public Dictionary<string, char> Plan = [];
    public Dictionary<string, char> Symbols = [];
    public List<SchematicNumber> SchematicNumbers = [];


    public Char GetCoordinate(Coordinate coord)
    {
        return GetCoordinate(coord.X, coord.Y);
    }

    public Char GetCoordinate(int x, int y)
    {
        var coord = Coordinate.ToRaw(x, y);
        return Plan.ContainsKey(coord) ? Plan[coord] : '.';
    }
}
