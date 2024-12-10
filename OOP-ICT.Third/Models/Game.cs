using OOP_ICT.Models;
using OOP_ICT.Second.Person;
using OOP_ICT.Third.Facades;
using OOP_ICT.UsersCards;

namespace OOP_ICT.Third.Models;

public class Game
{
    private List<Gamer> _listOfGamersPlaying;
    private Dealer _dealer;
    
    private const int CardToAddToHand = 1;
    private const int CardDealerGetsFirstTurn = 1;
    private const int CardsPlayerGetsFirstTurn = 2;
    
    public Game(List<Card> cardDeck, List<Gamer> listOfGamersPlaying)
    {
        _listOfGamersPlaying = listOfGamersPlaying;
        _dealer = new Dealer(cardDeck);
    }

    public List<Gamer> GetGamers()
    {
        return _listOfGamersPlaying;
    }

    public Dealer GetDealer()
    {
        return _dealer;
    }
     
    public void DealCards()
    {
        List<Card> initialDeck = _dealer.GetInitialDeck();
        List<Card> shuffledDeck = _dealer.ShuffleDeck();
        foreach (Gamer gamer in _listOfGamersPlaying)
        {
            _dealer.DealCardsToPlayers(gamer.GetListOfGamerCards(), CardsPlayerGetsFirstTurn);
        }
        _dealer.DealCardsToDealer(CardDealerGetsFirstTurn);
    }

    public void Bet(Gamer gamer, GameFacade gameFacade, int bet)
    {
        gameFacade.Bet(gamer, bet);
    }
    
    public void GiveOneCardToGamer(Gamer gamer)
    {
        GamerCards gamerCards = gamer.GetListOfGamerCards();
        _dealer.DealCardsToPlayers(gamer.GetListOfGamerCards(), CardToAddToHand);
    }

    public void GiveOneCardToDealer()
    {
        _dealer.DealCardsToDealer(CardToAddToHand);
    }

    public int GetPlayerPoints(Gamer gamer, GameFacade gameFacade, int newValueForAce)
    {
        int playerPoints = gameFacade.FindOutGamerPoints(gamer, newValueForAce);
        return playerPoints;
    }

    public int GetDealerPoints(GameFacade gameFacade, int newValueForAce)
    {
        int dealerPoints = gameFacade.FindOutDealerPoints(_dealer, newValueForAce);
        return dealerPoints;
    }

    public void GetWinner(Gamer gamer, GameFacade gameFacade, int playerPoints, int dealerPoints, int bet)
    {
        gameFacade.DetermineWinners(gamer, playerPoints, dealerPoints, bet);
    }

    public List<Card> GetDeck()
    {
        return _dealer.GetDeck();
    }
}