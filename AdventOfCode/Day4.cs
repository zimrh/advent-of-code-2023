using AdventOfCode.Common;
using AdventOfCode.Enums;

namespace AdventOfCode;

public class Day4 : AdventDay
{
    public int Run(TestType testType, Part part)
    {
        return Part.One == part ?
            PartOne(testType, part) :
            PartTwo(testType, part);
    }

    public int PartOne(TestType testType, Part part)
    {
        var total = 0;
        foreach(var line in ReadFromFile(testType, part))
        {
            var subTotal = 0;
            var card = new ScratchCard(line);
            foreach (var number in card.CardNumbers)
            {
                if(card.WinningNumbers.Contains(number))
                {
                    subTotal = subTotal == 0 ? 1 : subTotal * 2;
                }
            }
            total += subTotal;
        }
        return total;
    }

    public int PartTwo(TestType testType, Part part)
    {
        var totalCards = 0;
        var scratchCardIncrements = new List<ScratchCardIncrement>();
        foreach(var line in ReadFromFile(testType, part))
        {
            var matches = 0;
            var card = new ScratchCard(line);
            var newScratchCardIncrements = new List<ScratchCardIncrement>();
            for (int i = 0; i < scratchCardIncrements.Count; i++)
            {
                card.Instances += scratchCardIncrements[i].AddInstances;
                scratchCardIncrements[i].CardCount--;
                if (scratchCardIncrements[i].CardCount > 0)
                {
                    newScratchCardIncrements.Add(scratchCardIncrements[i]);
                }
            }
            scratchCardIncrements = newScratchCardIncrements;
            foreach (var number in card.CardNumbers)
            {
                if(card.WinningNumbers.Contains(number))
                {
                    matches++;
                }
            }
            if (matches > 0)
            {
                scratchCardIncrements.Add(new ScratchCardIncrement {
                    CardCount = matches,
                    AddInstances = card.Instances
                });
            }
            totalCards += card.Instances;
        }
        return totalCards;
    }
}
