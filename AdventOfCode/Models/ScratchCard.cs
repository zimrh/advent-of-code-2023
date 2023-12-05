namespace AdventOfCode;

public class ScratchCard
{
    public ScratchCard(string raw)
    {
        var cardIdAndNumbers = raw.Split(":", StringSplitOptions.RemoveEmptyEntries);
        var cardId = cardIdAndNumbers[0].Split(" ",StringSplitOptions.RemoveEmptyEntries);
        Id = int.Parse(cardId[1]);

        var allNumbers = cardIdAndNumbers[1].Split("|", StringSplitOptions.RemoveEmptyEntries);
        WinningNumbers = allNumbers[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
        CardNumbers = allNumbers[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
    }

    public int Id { get; set; }
    public HashSet<int> WinningNumbers { get; set; }
    public List<int> CardNumbers { get; set; }
    public int Matches { get; set; }
    public int Instances { get; set; } = 1;
}
