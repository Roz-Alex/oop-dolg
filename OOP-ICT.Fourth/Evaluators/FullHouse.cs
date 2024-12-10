using OOP_ICT.Second.Person;

namespace OOP_ICT.Fourth.Evaluators;

public class FullHouse
{
    public static bool HasFullHouse(Gamer gamer)
    {
        var cards = gamer.GetListOfGamerCards().GetCards();
        return cards.GroupBy(card => card.Rank)
                   .Any(group => group.Count() == 3) &&
               cards.GroupBy(card => card.Rank)
                   .Any(group => group.Count() == 2);
    }
}