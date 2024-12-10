using OOP_ICT.Models;
using OOP_ICT.UsersCards;

namespace OOP_ICT.UsersCards;

public class DealerCards : IUserCards
{
    private List<Card> _dealerCards;

    public DealerCards()
    {
        _dealerCards = new List<Card>();
    }

    public List<Card> GetCards()
    {
        return _dealerCards;
    }

    public void AddCard(Card card)
    {
        _dealerCards.Add(card);
    }

    public void FoldCards()
    {
        _dealerCards.Clear();
    }
}