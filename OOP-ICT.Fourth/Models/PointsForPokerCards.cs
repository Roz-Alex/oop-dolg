namespace OOP_ICT.Fourth.Models;

public class PointsForPokerCards
{
    public static Dictionary<string, int> PointsForCard = new Dictionary<string, int>
    {
        {"Ace", 14},
        { "King", 13 },
        { "Queen", 12 },
        { "Jack", 11 },
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

    public int GetPointForCard(string rank)
    {
        return PointsForCard[rank];
    }
}