namespace AdventOfCode.Enums;

public enum CardType
{
    /// <summary>
    /// All cards' labels are distinct: 23456
    /// </summary>
    HighCard,

    /// <summary>
    /// Two cards share one label, and the other three cards have a different label from the pair and each other: A23A4
    /// </summary>
    OnePair,

    /// <summary>
    /// Two cards share one label, two other cards share a second label, and the remaining card has a third label: 23432
    /// </summary>
    TwoPair,

    /// <summary>
    /// Three cards have the same label, and the remaining two cards are each different from any other card in the hand: TTT98
    /// </summary>
    ThreeOfAKind,

    /// <summary>
    /// Three cards have the same label, and the remaining two cards share a different label: 23332
    /// </summary>
    FullHouse,

    /// <summary>
    /// Four cards have the same label and one card has a different label: AA8AA
    /// </summary>
    FourOfAKind,
    
    /// <summary>
    /// All five cards have the same label: AAAAA
    /// </summary>
    FiveOfAKind,
}
