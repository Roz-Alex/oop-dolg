using OOP_ICT.Models;
using OOP_ICT.Second;
using OOP_ICT.Second.Person;
using OOP_ICT.Third.Facades;
using OOP_ICT.Third.Models;

namespace OOP_ICT.Third.Tests;
using Xunit;


public class Testing
{
    [Fact]
    public void ValuesOfCardsTesting()
    {
        PointsForCards pointsForCards = new PointsForCards();
        Card cardKing = new Card("Hearts", "King", true);
        string denomination = cardKing.Rank;
        int value = pointsForCards.GetPointForCard(denomination, 11);
        Assert.Equal(10, value);

        Card cardAce = new Card("Hearts", "Ace", true);
        string newDenomination = cardAce.Rank;
        int newValue = pointsForCards.GetPointForCard(newDenomination, 1);
        Assert.Equal(1, newValue);
    }

    [Fact]
    public void ListOfPlayersTesting()
    {
        CardDeck cards = new CardDeck();
        List<Card> cardDeck = cards.GenerateCardDeck();
        Gamer gamer1 = new Gamer("Ivan");
        Gamer gamer2 = new Gamer("Dima");
        List<Gamer> listGamers = new List<Gamer>() { gamer1, gamer2 };
        Game game = new Game(cardDeck, listGamers);
        List<Gamer> actualList = game.GetGamers();
        Assert.Equal(listGamers, actualList);
    }

    [Fact]
    public void DealCardsTesting()
    {
        CardDeck cards = new CardDeck();
        List<Card> cardDeck = cards.GenerateCardDeck();
        Gamer gamer1 = new Gamer("Ivan");
        List<Gamer> listGamers = new List<Gamer>() { gamer1 };
        Game game = new Game(cardDeck, listGamers);
        Dealer dealer = new Dealer(cardDeck);

        game.DealCards();

        Assert.Equal(49, game.GetDeck().Count);
        Assert.Equal(2, gamer1.GetListOfGamerCards().GetCards().Count);
        Assert.Equal(1, game.GetDealer().GetListOfDealerCards().GetCards().Count);
        game.GiveOneCardToGamer(gamer1);
        Assert.Equal(3, gamer1.GetListOfGamerCards().GetCards().Count);
        game.GiveOneCardToDealer();
        Assert.Equal(2, game.GetDealer().GetListOfDealerCards().GetCards().Count);
    }

    [Fact]
    public void BetTesting()
    {
        CardDeck cards = new CardDeck();
        List<Card> cardDeck = cards.GenerateCardDeck();
        Gamer gamer1 = new Gamer("Ivan");
        List<Gamer> listGamers = new List<Gamer>() { gamer1 };
        Game game = new Game(cardDeck, listGamers);
        CasinoAccount casinoAccount = new CasinoAccount(100);
        BlackjackCasino blackjackCasino = new BlackjackCasino(casinoAccount);
        Bank bank = new Bank();
        GameFacade gameFacade = new GameFacade(casinoAccount);

        bank.CreateBankAccount(gamer1);
        bank.TopUpAccount(gamer1, 50);
        blackjackCasino.CreateCasinoAccount(gamer1);

        Assert.Equal(50, gamer1.GamerBankAccount.GetBalance());
        ChipsMoneyExchange chipsMoneyExchange = new ChipsMoneyExchange();
        blackjackCasino.BuyChips(chipsMoneyExchange, gamer1, 50);
        Assert.Equal(50, gamer1.GamerCasinoAccount.GetBalance());
        game.Bet(gamer1, gameFacade, 10);
        Assert.Equal(40, gamer1.GamerCasinoAccount.GetBalance());
    }

    [Fact]
    public void DoesPlayerWin()
    {
        CardDeck cards = new CardDeck();
        List<Card> cardDeck = cards.GenerateCardDeck();
        Gamer gamer3 = new Gamer("Nika");
        List<Gamer> listGamers = new List<Gamer>() { gamer3 };
        Game game = new Game(cardDeck, listGamers);
        CasinoAccount casinoAccount = new CasinoAccount(100);
        BlackjackCasino blackjackCasino = new BlackjackCasino(casinoAccount);
        Bank bank = new Bank();
        GameFacade gameFacade = new GameFacade(casinoAccount);

        bank.CreateBankAccount(gamer3);
        bank.TopUpAccount(gamer3, 50);
        blackjackCasino.CreateCasinoAccount(gamer3);
        ChipsMoneyExchange chipsMoneyExchange = new ChipsMoneyExchange();
        blackjackCasino.BuyChips(chipsMoneyExchange, gamer3, 50);
        game.Bet(gamer3, gameFacade, 10);
        game.GetDealer().ShuffleDeck();
        game.DealCards();
        gamer3.GetListOfGamerCards().AddCard(new Card("Clubs", "Ace", false));
        Assert.Equal(21, game.GetPlayerPoints(gamer3, gameFacade, 1));
        game.GetWinner(gamer3, gameFacade, game.GetPlayerPoints(gamer3, gameFacade, 1),
            game.GetDealerPoints(gameFacade, 1), 10);
        Assert.Equal(60, gamer3.GamerCasinoAccount.GetBalance());
    }
} 