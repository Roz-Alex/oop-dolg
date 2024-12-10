using OOP_ICT.Second.Person;

namespace OOP_ICT.Second.lab_3.Interfaces;

public interface IGame
{
    void DealCards();
    void AddPlayerToGame(Gamer gamer);
    void AddOneCardToGamer(Gamer gamer);
}