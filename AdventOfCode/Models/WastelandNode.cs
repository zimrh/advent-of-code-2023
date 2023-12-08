namespace AdventOfCode.Models;

public class WastelandNode
{
    public WastelandNode(string line)
    {
        var split = line.Split("=", StringSplitOptions.RemoveEmptyEntries);
        Id = split[0].Trim();
        var directions = split[1].Split(",");
        LeftNode = directions[0].Trim().Trim('(');
        RightNode = directions[1].Trim().Trim(')');
    }

    public string Id { get; set; } = string.Empty;
    public string LeftNode { get; set; } = string.Empty;
    public string RightNode { get; set; } = string.Empty;

}
