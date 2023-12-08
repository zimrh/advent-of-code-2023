using AdventOfCode.Common;
using AdventOfCode.Enums;

namespace AdventOfCode;

public class Day7 : AdventDay
{
    public int Run(TestType testType, Part part)
    {
        var hands = GetHands(testType, part);
        var sortedHands = hands
            .OrderBy(h => h.HandType)
            .ThenBy(h => h)
            .ToList();
        
        foreach(var sortedHand in sortedHands){
            Console.WriteLine($"{new string(sortedHand.Cards.ToArray())}, {sortedHand.HandType}");
        }

        var winnings = 0;
        for (int i = 0; i < sortedHands.Count; i++)
        {
            winnings += sortedHands[i].Bid * (i + 1);
        }
        return winnings;
    }

    public List<CamelCardHand> GetHands(TestType testType, Part part)
    {
        var hands = new List<CamelCardHand>();
        foreach(var line in ReadFromFile(testType, part))
        {
            hands.Add(new CamelCardHand(line, part == Part.Two));
        }
        return hands;
    }
}
