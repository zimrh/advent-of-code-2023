namespace AdventOfCode.Models;

public class GardenMapRule
{
    public GardenMapRule(string input)
    {
        var numbers = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        SourceStart = int.Parse(numbers[1]);
        DestinationStart = int.Parse(numbers[0]);
        Range = int.Parse(numbers[2]);
        Diff = DestinationStart - SourceStart;
    }

    public int SourceStart { get; set; }
    
    public int SourceEnd => SourceStart + Range - 1;
    public int DestinationStart { get; set; }
    public int DestinationEnd => DestinationStart + Range - 1;
    public int Range { get; set; }
    public int Diff { get; set; }
    
}
