using System.Data;
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
    
    public Coordinate Move(Direction direction)
    {
        return Move(this, direction);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            throw new NoNullAllowedException("compared card cannot be null");
        }
        var sameType = string.Compare(GetType().Name, obj.GetType().Name, StringComparison.Ordinal) == 0;
        if (!sameType)
        {
            throw new InvalidCastException($"{obj.GetType().Name} is not {GetType().Name}");
        }
        var secondCoord = (Coordinate)obj;

        return X == secondCoord.X &&
                Y == secondCoord.Y;
    }

    public static Direction GetDirection(Coordinate startPoint, Coordinate endPoint)
    {
        var x = startPoint.X - endPoint.X;
        var y = startPoint.Y - endPoint.Y;
        if (x == 0 && y == 0) { return Direction.DoNot; }
        if (x == 0 && y <  0) { return Direction.Down; }
        if (x == 0 && y >  0) { return Direction.Up; }
        if (x <  0 && y == 0) { return Direction.Right; }
        if (x <  0 && y >  0) { return Direction.UpRight; }
        if (x <  0 && y <  0) { return Direction.DownRight; }
        if (x >  0 && y == 0) { return Direction.Left; }
        if (x >  0 && y >  0) { return Direction.UpLeft; }
        if (x >  0 && y <  0) { return Direction.DownLeft; }
        throw new ArgumentOutOfRangeException("Not sure how you got here but welcome, have an exception");
    }

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
