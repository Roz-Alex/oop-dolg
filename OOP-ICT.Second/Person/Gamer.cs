using OOP_ICT.Models;
using OOP_ICT.Second.Accounts;
using OOP_ICT.UsersCards;

namespace OOP_ICT.Second.Person;

public class Gamer : IGamer
{
    public string Name { get; }
    public int Id { get; }
    private GamerCards _gamerCards;
    public int Combination;

    public GamerBankAccount GamerBankAccount { get; set; }
    public GamerCasinoAccount GamerCasinoAccount { get; set; }

    private static int _nextId = 1000;

    public Gamer(string name)
    {
        Name = name;
        Id = GenerateUniqueId();
        _gamerCards = new GamerCards();
    }

    public int GenerateUniqueId()
    {
        int newId = _nextId++;
        return newId;
    }

    public GamerCards GetListOfGamerCards()
    {
        return _gamerCards;
    }

    public void ReceiveCard(Card card)
    {
        _gamerCards.AddCard(card);
    }
}