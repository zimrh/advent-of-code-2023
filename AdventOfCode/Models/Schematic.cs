namespace AdventOfCode.Models;

public class Schematic
{
    public Dictionary<string, char> Plan = [];
    public List<string> Symbols = [];
    public List<SchematicNumber> SchematicNumbers = [];

    public Char GetCoordinate(int x, int y)
    {
        var coord = Coordinate.ToRaw(x, y);
        return Plan.ContainsKey(coord) ? Plan[coord] : '.';
    }
    

}
