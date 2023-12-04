namespace AdventOfCode.Models;

public class Game
{
    public int Id { get; set; }
    public List<Dictionary<Color, int>> Draws { get; set; } = [];
    public static Color GetColor(string color)
    {
        return color.ToLowerInvariant() switch
        {
            "green" => Color.Green,
            "red" => Color.Red,
            "blue" => Color.Blue,
            _ => Color.Unknown
        };
    }
}
