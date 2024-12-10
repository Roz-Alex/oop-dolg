using OOP_ICT.Second.Person;

namespace OOP_ICT.Fourth.Evaluators;

public class TwoPairs
{
    public static bool HasTwoPairs(Gamer gamer)
    {
        var cards = gamer.GetListOfGamerCards().GetCards();
        
        return cards.GroupBy(card => card.Rank)
            .Count(group => group.Count() == 2) == 2;
    }
}