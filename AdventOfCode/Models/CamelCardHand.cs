using System.Data;
using AdventOfCode.Enums;

namespace AdventOfCode;

public class CamelCardHand : IComparable
{
    public CamelCardHand(string line, bool hasJokers)
    {
        var split = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var cardCounts = new Dictionary<char, int>();
        foreach(var card in split[0])
        {
            Cards.Add(card);
            if (!cardCounts.ContainsKey(card))
            {
                cardCounts.Add(card, 0);
            }
            cardCounts[card]++;
        }
        HasJokers = hasJokers;
        HandType = GetCamelCardHandType(cardCounts, hasJokers);
        Bid = int.Parse(split[1]);
    }
    public List<char> Cards { get; set; } = [];
    public int Bid { get; set; }
    public bool HasJokers { get; set; }
    public CamelCardHandType HandType { get; set; }

    public int CompareTo(object? obj)
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
        var secondHand = (CamelCardHand)obj;

        for (int i = 0; i < Cards.Count; i++)
        {
            var thisCardValue = GetCardValue(Cards[i], HasJokers);
            var comparedCardValue = GetCardValue(secondHand.Cards[i], HasJokers);
            if (thisCardValue == comparedCardValue)
            {
                continue;
            }
            return thisCardValue - comparedCardValue;
        }

        return 0;
    }

    public static int GetCardValue(char c, bool hasJokers)
        => c switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => hasJokers ? 1 : 11,
            'T' => 10,
            _ => int.Parse(c.ToString())
        };

    public static CamelCardHandType GetCamelCardHandType(IDictionary<char, int> cardCounts, bool hasJokers)
    {
        if (hasJokers && cardCounts.ContainsKey('J'))
        {
            if (cardCounts['J'] == 5) {
                return CamelCardHandType.FiveOfAKind;
            }
            var list = cardCounts.Where(c => c.Key != 'J').OrderByDescending(c => c.Value);
            var largestCount = list.First();
            cardCounts[largestCount.Key] += cardCounts['J'];
            cardCounts.Remove('J');
        }

        // Usually would error check to ensure we have a total of 5 but skipping for now
        switch(cardCounts.Count)
        {
            case 1:
                return CamelCardHandType.FiveOfAKind;
            
            case 2:
                var count = cardCounts.First().Value;
                if (count == 1 || count == 4)
                {
                    return CamelCardHandType.FourOfAKind;
                }
                else
                {
                    return CamelCardHandType.FullHouse;
                }
            
            case 3:
                foreach(var cardCount in cardCounts)
                {
                    if (cardCount.Value == 3)
                    {
                        return CamelCardHandType.ThreeOfAKind;
                    }
                    if (cardCount.Value == 2)
                    {
                        return CamelCardHandType.TwoPair;
                    }
                }
                return CamelCardHandType.Unknown;

            case 4:
                return CamelCardHandType.OnePair;

            default:
                return CamelCardHandType.HighCard;
        }
    }
}
