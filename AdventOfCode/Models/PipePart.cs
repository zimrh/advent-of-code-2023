using AdventOfCode.Enums;

namespace AdventOfCode.Models;

public class PipePart(char c)
{
    public char Symbol { get; set; } = c;
    public List<Direction> GetAvailableDirections()
    {
        switch (Symbol)
        {
            case '|':
                return [Direction.Up, Direction.Down];
            case '-':
                return [Direction.Left, Direction.Right];
            case 'L':
                return [Direction.Up, Direction.Right];
            case 'J':
                return [Direction.Up, Direction.Left];
            case '7':
                return [Direction.Down, Direction.Left];
            case 'F':
                return [Direction.Down, Direction.Right];
            default:
                throw new ArgumentOutOfRangeException($"{Symbol} is not a valid pipe part");
        }
    }
}
