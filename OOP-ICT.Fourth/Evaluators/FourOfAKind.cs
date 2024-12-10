using OOP_ICT.Second.Person;

namespace OOP_ICT.Fourth.Evaluators;

public class FourOfAKind
{
    public static bool HasFourOfAKind(Gamer gamer)
    {
        var cards = gamer.GetListOfGamerCards().GetCards();
        return cards.GroupBy(card => card.Rank)
            .Any(group => group.Count() == 4);
    }
}