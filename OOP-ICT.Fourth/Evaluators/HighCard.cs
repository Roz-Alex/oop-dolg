using OOP_ICT.Models;
using OOP_ICT.Second.Person;

namespace OOP_ICT.Fourth.Evaluators;

public class HighCard
{
    public static bool HasHighCard(Gamer gamer)
    {
        var cards = gamer.GetListOfGamerCards().GetCards();
        cards.Sort();
        return cards.DistinctBy(card => card.Rank).Count() == 5;
    }

    public Card GetHighCard(Gamer gamer)
    {
        var cards = gamer.GetListOfGamerCards().GetCards();
        cards.Sort();
        return cards[cards.Count - 1];
    }
}