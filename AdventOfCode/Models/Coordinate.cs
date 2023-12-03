namespace AdventOfCode;

public class Coordinate
{
    public Coordinate() { }

    public Coordinate(string raw)
    {
        var coords = raw.Split(":");
        X = int.Parse(coords[0]);
        Y = int.Parse(coords[1]);
    }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X;

    public int Y;

    public override string ToString()
    {
        return $"{X}:{Y}";
    }

    public static string ToRaw(int x, int y)
        => $"{x}:{y}";
}
