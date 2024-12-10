using OOP_ICT.Second.MyExceptions;

namespace OOP_ICT.Third;

public class PointsForCards
{
    public static Dictionary<string, int> PointsForCard = new Dictionary<string, int>
    {
        { "King", 10 },
        { "Queen", 10 },
        { "Jack", 10 },
        { "Ten", 10 },
        { "Nine", 9 },
        { "Eight", 8 },
        { "Seven", 7 },
        { "Six", 6 },
        { "Five", 5 },
        { "Four", 4 },
        { "Three", 3 },
        { "Two", 2 },
    };

    public int GetPointForCard(string rank, int newValueForAce)
    {
        if (rank == "Ace")
        {
            if (newValueForAce != 1 && newValueForAce != 11)
            {
                throw new InvalidPointForAceException("Point for ace should be 1 or 11");
            }
            return newValueForAce; 
        }
        return PointsForCard[rank];
    }
}