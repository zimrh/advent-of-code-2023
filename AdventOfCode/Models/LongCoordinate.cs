using System.Data;
using AdventOfCode.Enums;

namespace AdventOfCode;

public class LongCoordinate
{
    public LongCoordinate() { }

    public LongCoordinate(LongCoordinate coordinate)
    {
        X = coordinate.X;
        Y = coordinate.Y;
    }

    public LongCoordinate(LongCoordinate coordinate, Direction direction)
    {
        X = coordinate.X;
        Y = coordinate.Y;
        Move(this, direction);
    }

    public LongCoordinate(string raw)
    {
        var coords = raw.Split(":");
        X = long.Parse(coords[0]);
        Y = long.Parse(coords[1]);
    }

    public LongCoordinate(long x, long y)
    {
        X = x;
        Y = y;
    }

    public long X;

    public long Y;

    public override string ToString()
    {
        return $"{X}:{Y}";
    }

    public static string ToRaw(long x, long y)
        => $"{x}:{y}";
    
    public LongCoordinate Move(Direction direction)
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
        var secondCoord = (LongCoordinate)obj;

        return X == secondCoord.X &&
                Y == secondCoord.Y;
    }

    public static Direction GetDirection(LongCoordinate startPolong, LongCoordinate endPolong)
    {
        var x = startPolong.X - endPolong.X;
        var y = startPolong.Y - endPolong.Y;
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

    public static LongCoordinate Move(LongCoordinate coord, Direction direction)
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

    internal static long GetDistance(string firstGalaxy, string secondGalaxy)
    {
        var first = new LongCoordinate(firstGalaxy);
        var second = new LongCoordinate(secondGalaxy);
        var xDiff = first.X > second.X ? first.X - second.X : second.X - first.X;
        var yDiff = first.Y > second.Y ? first.Y - second.Y : second.Y - first.Y;
        return xDiff + yDiff;
    }
}
