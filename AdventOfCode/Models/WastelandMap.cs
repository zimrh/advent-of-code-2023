namespace AdventOfCode.Models;

public class WastelandMap
{
    public List<char> Directions { get; set; } = [];
    public Dictionary<string, WastelandNode> Nodes { get; set; } = [];
}
