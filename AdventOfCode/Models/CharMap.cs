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

    public int GetBottom()
    {
        var bottom = 0;
        foreach(var entry in Map)
        {
            var coord = new Coordinate(entry.Key);
            bottom = coord.Y > bottom ? coord.Y : bottom;
        }
        return bottom;
    }

    public int GetRight()
    {
        var right = 0;
        foreach(var entry in Map)
        {
            var coord = new Coordinate(entry.Key);
            right = coord.X > right ? coord.X : right;
        }
        return right;
    }
}
