using OOP_ICT.Second.Person;

namespace OOP_ICT.Fourth.Evaluators;

public class Evaluator
{
    private static readonly Dictionary<Func<Gamer, bool>, int> CombinationMappings =
        new Dictionary<Func<Gamer, bool>, int>
        {
            { RoyalFlush.HasRoyalFlush, 1 },
            { StraighFlush.HasStraightFlush, 2 },
            { FourOfAKind.HasFourOfAKind, 3 },
            { FullHouse.HasFullHouse, 4 },
            { Flush.HasFlush, 5 },
            { Straight.HasStraight, 6 },
            { Set.HasSet, 7 },
            { TwoPairs.HasTwoPairs, 8 },
            { Pair.HasPair, 9 },
            { HighCard.HasHighCard, 10 }
        };

    private static readonly Dictionary<Func<Gamer, bool>, string> CombinationsNames =
        new Dictionary<Func<Gamer, bool>, string>
        {
            { RoyalFlush.HasRoyalFlush, "Royal Flush" },
            { StraighFlush.HasStraightFlush, "Straight Flush" },
            { FourOfAKind.HasFourOfAKind, "Four Of A Kind" },
            { FullHouse.HasFullHouse, "Full House" },
            { Flush.HasFlush, "Flush" },
            { Straight.HasStraight, "Straight" },
            { Set.HasSet, "Set" },
            { TwoPairs.HasTwoPairs, "Two Pairs" },
            { Pair.HasPair, "Pair" },
            { HighCard.HasHighCard, "High Card" }
        };

    public int GetCombination(Gamer gamer)
    {
        foreach (var mapping in CombinationMappings)
        {
            if (mapping.Key(gamer))
            {
                gamer.Combination = mapping.Value;
                return mapping.Value;
            }
        }

        return 0;
    }

    public string GetCombinationName(int combinationNumber)
    {
        var mapping = CombinationMappings.FirstOrDefault(pair => pair.Value == combinationNumber);
        if (mapping.Key != null && CombinationsNames.TryGetValue(mapping.Key, out var combinationName))
        {
            return combinationName;
        }

        return "Unknown Combination";
    }
}