namespace AdventOfCode.Models;

public class CharMap
{
    public Dictionary<string, char> Map = [];

    public Char GetCoordinate(Coordinate coord)
    {
        return GetCoordinate(coord.X, coord.Y);
    }

    public Char GetCoordinate(int x, int y)
    {
        var coord = Coordinate.ToRaw(x, y);
        return Map.ContainsKey(coord) ? Map[coord] : '.';
    }
}
