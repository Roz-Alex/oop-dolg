using OOP_ICT.Models;

namespace OOP_ICT.UsersCards;

public interface IUserCards
{
    List<Card> GetCards();
    void AddCard(Card card);
    void FoldCards();
}