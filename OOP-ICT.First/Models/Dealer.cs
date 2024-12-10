using OOP_ICT.UsersCards;

namespace OOP_ICT.Models;


public class Dealer
{
    private List<Card> _cards;
    private DealerCards _dealerCards;

    public Dealer(List<Card> deck)
    {
        _cards = deck;
        _dealerCards = new DealerCards();
    }

    private List<Card> PerfectShuffle(List<Card> deck)
    {
        int half = deck.Count / 2;
        List<Card> shuffledDeck = new List<Card>();
        for (int i = 0; i < half; i++)
        {
            shuffledDeck.Add(deck[i]);
            shuffledDeck.Add(deck[i + half]);
        }
        return shuffledDeck;
    }
    
    public List<Card> GetInitialDeck()
    {
        _cards = new CardDeck().GenerateCardDeck();
        return _cards;
    }
    
    public List<Card> ShuffleDeck()
    {
        _cards = PerfectShuffle(_cards);
        return _cards;
    }

    public List<Card> GetDeck()
    {
        return _cards;
    }

    public DealerCards GetListOfDealerCards()
    {
        return _dealerCards;
    }
    
    public void DealCardsToPlayers(GamerCards gamerCards, int numberOfCardsToDeal)
    {
        int amountOfCardsAvailable = _cards.Count;
    
        for (int i = 0; i < numberOfCardsToDeal && amountOfCardsAvailable > 0; i++)
        {
            int lastIndex = amountOfCardsAvailable - 1;
            Card card = _cards[lastIndex];
        
            gamerCards.AddCard(card);
            _cards.RemoveAt(lastIndex);
        
            amountOfCardsAvailable = _cards.Count; 
        }
    }

    public void DealCardsToDealer(int numberOfCardsToDeal)
    {
        int amountOfCardsAvailable = _cards.Count;

        for (int i = 0; i < numberOfCardsToDeal && amountOfCardsAvailable > 0; i++)
        {
            int lastIndex = amountOfCardsAvailable - 1;
            Card card = _cards[lastIndex];

            _dealerCards.AddCard(card);
            _cards.RemoveAt(lastIndex);

            amountOfCardsAvailable = _cards.Count; 
        }
    }

    public void DealCommonCards(List<Card> cards, int numberOfCardsToDeal)
    {
        int amountOfCardsAvailable = _cards.Count;
    
        for (int i = 0; i < numberOfCardsToDeal && amountOfCardsAvailable > 0; i++)
        {
            int lastIndex = amountOfCardsAvailable - 1;
            Card card = _cards[lastIndex];
        
            cards.Add(card);
            _cards.RemoveAt(lastIndex);
        
            amountOfCardsAvailable = _cards.Count; 
        }
    }
}