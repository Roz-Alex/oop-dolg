using OOP_ICT.Fourth.Evaluators;
using OOP_ICT.Models;
using OOP_ICT.Second;
using OOP_ICT.Second.Accounts;
using OOP_ICT.Second.MyExceptions;
using OOP_ICT.Second.Person;

namespace OOP_ICT.Fourth.Models;

public class Poker
{
    private List<Gamer> _gamers;
    private List<Card> _commonCards;
    private List<int> _listOfGamersCombinations;
    private static int Bank;
    private Casino _casino;

    public Poker(CasinoAccount casinoAccount)
    {
        _gamers = new List<Gamer>();
        _commonCards = new List<Card>();
        _listOfGamersCombinations = new List<int>();
        Bank = 0;
        _casino = new Casino(casinoAccount);
    }

    public static void AddBetToBank(int bet)
    {
        Bank += bet;
    }

    public void Enter(Gamer gamer)
    {
        _gamers.Add(gamer);
    }

    public void Leave(Gamer gamer)
    {
        _gamers.Remove(gamer);
    }

    public List<Gamer> GetGamers()
    {
        return _gamers;
    }

    public List<Card> GetCommonCards()
    {
        return _commonCards;
    }

    public void DealFirstTurn(Dealer dealer)
    {
        foreach (Gamer gamer in _gamers)
        {
            dealer.DealCardsToPlayers(gamer.GetListOfGamerCards(), 2);
        }
    }

    public void DealSecondTurn(Dealer dealer)
    {
        dealer.DealCommonCards(_commonCards, 3);
        foreach (Gamer gamer in _gamers)
        {
            foreach (Card card in _commonCards)
            {
                gamer.ReceiveCard(card);
            }
        }
    }

    public void DealLastTwoTurns(Dealer dealer, int numberOfCards)
    {
        dealer.DealCommonCards(_commonCards, numberOfCards);
        foreach (Gamer gamer in _gamers)
        {
            gamer.ReceiveCard(_commonCards[_commonCards.Count-1]);
        }
    }

    public void DealThirdTurn(Dealer dealer)
    {
        DealLastTwoTurns(dealer, 1);
    }

    public void DealLastTurn(Dealer dealer)
    {
        DealLastTwoTurns(dealer, 1);
    }

    public void GetGamersCombinations()
    {
        Evaluator evaluator = new Evaluator();
        foreach (Gamer gamer in _gamers)
        {
            evaluator.GetCombination(gamer);
            _listOfGamersCombinations.Add(gamer.Combination);
        }
    }

    public Gamer DetermineWinner()
    {
        GetGamersCombinations();
        _listOfGamersCombinations.Sort();
        foreach (Gamer gamer in _gamers)
        {
            if (gamer.Combination == _listOfGamersCombinations[0])
            {
                return gamer;
            }
        }
        return null;
    }
    
    public void MakeBet(Gamer gamer, int chips)
    {
        if (chips <= 0)
        {
            throw new NegativeCurrencyException("Bet should be > 0");
        }
        gamer.GamerCasinoAccount.WithdrawCurrency(chips); // withdraw amount of bet from casino account
        AddBetToBank(chips);
    }

    public void AccrueWinningToWinner(Gamer gamer)
    {
        GamerCasinoAccount gamerCasinoAccount = gamer.GamerCasinoAccount;
        gamerCasinoAccount.AddCurrency(Bank);
    }

    public int GetWinning()
    {
        return Bank;
    }
}