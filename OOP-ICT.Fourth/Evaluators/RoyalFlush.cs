using OOP_ICT.Models;
using OOP_ICT.Second.Person;

namespace OOP_ICT.Fourth.Evaluators;

public class RoyalFlush
{
    public static bool HasRoyalFlush(Gamer gamer)
    {
        var cards = gamer.GetListOfGamerCards().GetCards();
        return cards.GroupBy(card => card.Suit)
            .Any(group => group.Select(card => card.Rank)
                .OrderBy(rank => rank)
                .SequenceEqual(GetRoyalFlushRanks().Select(rank => rank.ToString())));
    }
    
    private static List<Ranks> GetRoyalFlushRanks()
    {
        return new List<Ranks> { Ranks.Ten, Ranks.Jack, Ranks.Queen, Ranks.King, Ranks.Ace };
    }
}