using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;
using OOP_ICT.Second.Person;

namespace OOP_ICT.Fourth.Evaluators;

public class Straight
{
    public static bool HasStraight(Gamer gamer)
    {
        var allCards = GetRankValues(gamer.GetListOfGamerCards().GetCards());
        allCards.Sort();
        
        for (int i = 0; i <= allCards.Count - 5; i++)
        {
            var fiveCards = allCards.GetRange(i, 5);
            
            if (fiveCards.Distinct().Count() == 5)
            {
                int minRank = fiveCards.Min();
                int maxRank = fiveCards.Max();
                if (maxRank - minRank == 4)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    private static List<int> GetRankValues(List<Card> cards)
    {
        PointsForPokerCards pointsForPokerCards = new PointsForPokerCards();
        return cards.Select(card => pointsForPokerCards.GetPointForCard(card.Rank)).ToList();
    }
}