using OOP_ICT.Fourth.Evaluators;
using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;
using OOP_ICT.Second;
using OOP_ICT.Second.Person;
using Xunit;

namespace OOP_ICT.Fourth.Tests;

public class Test
{
    [Fact]
    public void EnterLeaveGameTest()
    {
        CardDeck cardDeck = new CardDeck();
        var deck = cardDeck.GenerateCardDeck();
        CasinoAccount casinoAccount = new CasinoAccount(1000);
        Poker poker = new Poker(casinoAccount);
        var gamer = new Gamer("Ivan");
        
        poker.Enter(gamer);
        Assert.Equal(1, poker.GetGamers().Count);
        
        poker.Leave(gamer);
        Assert.Empty(poker.GetGamers());
    }

    [Fact]
    public void DealTest()
    {
        CardDeck cardDeck = new CardDeck();
        var deck = cardDeck.GenerateCardDeck();
        Dealer dealer = new Dealer(deck);
        dealer.ShuffleDeck();
        CasinoAccount casinoAccount = new CasinoAccount(1000);
        Poker poker = new Poker(casinoAccount);
        
        var gamer = new Gamer("Ivan");
        var gamer1 = new Gamer("Dima");
        
        poker.Enter(gamer);
        poker.Enter(gamer1);
        
        poker.DealFirstTurn(dealer);
        Assert.Equal(2, gamer.GetListOfGamerCards().GetCards().Count);
        Assert.Equal(2, gamer1.GetListOfGamerCards().GetCards().Count);
        Assert.Empty(poker.GetCommonCards());
        
        poker.DealSecondTurn(dealer);
        Assert.Equal(5, gamer.GetListOfGamerCards().GetCards().Count);
        Assert.Equal(5, gamer1.GetListOfGamerCards().GetCards().Count);
        Assert.Equal(3, poker.GetCommonCards().Count);
        
        poker.DealThirdTurn(dealer);
        Assert.Equal(6, gamer.GetListOfGamerCards().GetCards().Count);
        Assert.Equal(6, gamer1.GetListOfGamerCards().GetCards().Count);
        Assert.Equal(4, poker.GetCommonCards().Count);
        
        poker.DealLastTurn(dealer);
        Assert.Equal(7, gamer.GetListOfGamerCards().GetCards().Count);
        Assert.Equal(7, gamer1.GetListOfGamerCards().GetCards().Count);
        Assert.Equal(5, poker.GetCommonCards().Count);
    }

    [Fact]
    public void CombinationsEvaluatorTest()
    {
        var gamer = new Gamer("Ivan");
        var evaluator = new Evaluator();
        
        gamer.ReceiveCard(new Card("Diamonds", "Ace", false));
        gamer.ReceiveCard(new Card("Hearts", "Ace", false));
        gamer.ReceiveCard(new Card("Diamonds", "King", false));
        gamer.ReceiveCard(new Card("Hearts", "Two", false));
        gamer.ReceiveCard(new Card("Hearts", "Three", false));
        gamer.ReceiveCard(new Card("Hearts", "Four", false));
        gamer.ReceiveCard(new Card("Hearts", "Five", false));
        
        Assert.Equal(5, evaluator.GetCombination(gamer));
    }

    [Fact]
    public void WinnerTest()
    {
        CardDeck cardDeck = new CardDeck();
        var deck = cardDeck.GenerateCardDeck();
        Dealer dealer = new Dealer(deck);
        dealer.ShuffleDeck();
        CasinoAccount casinoAccount = new CasinoAccount(1000);
        Poker poker = new Poker(casinoAccount);
        
        var gamer = new Gamer("Ivan");
        var gamer1 = new Gamer("Dima");
        
        poker.Enter(gamer);
        poker.Enter(gamer1);
        
        poker.DealFirstTurn(dealer);
        poker.DealSecondTurn(dealer);
        poker.DealThirdTurn(dealer);
        poker.DealLastTurn(dealer);
        Assert.Equal(gamer, poker.DetermineWinner());
    }
}