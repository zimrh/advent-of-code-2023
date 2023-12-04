using AdventOfCode.Enums;

namespace AdventOfCode;

public class Coordinate
{
    public Coordinate() { }

    public Coordinate(Coordinate coordinate)
    {
        X = coordinate.X;
        Y = coordinate.Y;
    }

    public Coordinate(Coordinate coordinate, Direction direction)
    {
        X = coordinate.X;
        Y = coordinate.Y;
        Move(this, direction);
    }

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
    
    public static Coordinate Move(Coordinate coord, Direction direction)
    {
        switch(direction)
        {
            case Direction.Up:
                coord.Y += -1;
                return coord;
                
            case Direction.UpRight:
                coord.X += 1;
                coord.Y += -1;
                return coord;

            case Direction.Right:
                coord.X += 1;
                return coord;

            case Direction.DownRight:
                coord.X += 1;
                coord.Y += 1;
                return coord;

            case Direction.Down:
                coord.Y += 1;
                return coord;

            case Direction.DownLeft:
                coord.X += -1;
                coord.Y += 1;
                return coord;
                
            case Direction.Left:
                coord.X += -1;
                return coord;
                
            case Direction.UpLeft:
                coord.X += -1;
                coord.Y += -1;
                return coord;

            default:
                return coord;
        }
    }
}
