using AdventOfCode;
using AdventOfCode.Enums;
using NUnit.Framework.Internal;

namespace AdventOfCodeTests;

public class Day7Tests
{
    
    [Test]
    public void TestJokers()
    {
        foreach(var test in GetTestData())
        {
            var cardCounts = new Dictionary<char, int>();
            foreach(var card in test.Key)
            {
                if (!cardCounts.ContainsKey(card))
                {
                    cardCounts.Add(card, 0);
                }
                cardCounts[card]++;
            }
            var cardType = CamelCardHand.GetCamelCardHandType(cardCounts, true);
            if (cardType != test.Value)
            {
                Assert.Fail();
            }

        }
        Assert.Pass();

        
    }

    public IDictionary<string, CamelCardHandType> GetTestData()
    {
        return new Dictionary<string, CamelCardHandType>{
            {"JJQ4A",CamelCardHandType.ThreeOfAKind},
            {"47TJ4",CamelCardHandType.ThreeOfAKind},
            {"KJKKK",CamelCardHandType.FiveOfAKind},
            {"JK9T3",CamelCardHandType.OnePair},
            {"82J22",CamelCardHandType.FourOfAKind},
            {"Q266J",CamelCardHandType.ThreeOfAKind},
            {"682J6",CamelCardHandType.ThreeOfAKind},
            {"9J999",CamelCardHandType.FiveOfAKind},
            {"K269J",CamelCardHandType.OnePair},
            {"7442J",CamelCardHandType.ThreeOfAKind},
            {"8AJ83",CamelCardHandType.ThreeOfAKind},
            {"36J6K",CamelCardHandType.ThreeOfAKind},
            {"J8228",CamelCardHandType.FullHouse},
            {"J9285",CamelCardHandType.OnePair},
            {"5825J",CamelCardHandType.ThreeOfAKind},
            {"8JA6Q",CamelCardHandType.OnePair},
            {"QJ777",CamelCardHandType.FourOfAKind},
            {"Q8J63",CamelCardHandType.OnePair},
            {"69J9T",CamelCardHandType.ThreeOfAKind},
            {"3369J",CamelCardHandType.ThreeOfAKind},
            {"TA92J",CamelCardHandType.OnePair},
            {"47JQT",CamelCardHandType.OnePair}
        };
    }
}
