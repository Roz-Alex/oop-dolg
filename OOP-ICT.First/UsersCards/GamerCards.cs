using OOP_ICT.Models;

namespace OOP_ICT.UsersCards;

public class GamerCards : IUserCards
{
    private List<Card> _gamerCards;

    public GamerCards()
    {
        _gamerCards = new List<Card>();
    }

    public List<Card> GetCards()
    {
        return _gamerCards;
    }

    public void AddCard(Card card)
    {
        _gamerCards.Add(card);
    }

    public void FoldCards()
    {
        _gamerCards.Clear();
    }
}