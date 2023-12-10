using AdventOfCode.Enums;

namespace AdventOfCode.Models;

public class PipeMap : CharMap
{
    public Coordinate StartingPoint { get; set; } = new();

    public PipePart GetPipePart(Coordinate coordinate)
    {
        return new PipePart(GetCoordinate(coordinate));
    }

    public List<Direction> GetValidStartDirections(Coordinate coord)
    {
        var validDirections = new List<Direction>();
        var up = GetCoordinate(new Coordinate(coord, Direction.Up));
        if (up == '|' || up == 'F' || up == '7')
        {
            validDirections.Add(Direction.Up);
        }
        var down = GetCoordinate(new Coordinate(coord, Direction.Down));
        if (down == '|' || down == 'J' || down == 'L')
        {
            validDirections.Add(Direction.Down);
        }        
        var left = GetCoordinate(new Coordinate(coord, Direction.Left));
        if (left == '-' || left == 'F' || left == 'L')
        {
            validDirections.Add(Direction.Left);
        }
        var right = GetCoordinate(new Coordinate(coord, Direction.Right));
        if (right == '-' || right == 'J' || right == '7')
        {
            validDirections.Add(Direction.Right);
        }
        return validDirections;
    }
}
