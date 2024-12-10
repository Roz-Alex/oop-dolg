using OOP_ICT.Second.Person;

namespace OOP_ICT.Fourth.Evaluators;

public class Flush
{
    public static bool HasFlush(Gamer gamer)
    {
        var cards = gamer.GetListOfGamerCards().GetCards();
        return cards.GroupBy(card => card.Suit)
            .Any(group => group.Count() >= 5);
    }
}