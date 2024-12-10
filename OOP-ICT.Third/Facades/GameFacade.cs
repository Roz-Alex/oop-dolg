using OOP_ICT.Models;
using OOP_ICT.Second;
using OOP_ICT.Second.Accounts;
using OOP_ICT.Second.lab_3;
using OOP_ICT.Second.Person;
using Card = OOP_ICT.Models.Card;

namespace OOP_ICT.Third.Facades;

public class GameFacade
{
    private BlackjackCasino _blackjackCasino;

    public GameFacade(CasinoAccount casinoAccount)
    {
        _blackjackCasino = new BlackjackCasino(casinoAccount);
    }

    public void Bet(Gamer gamer, int bet)
    {
        GamerCasinoAccount account = gamer.GamerCasinoAccount;
        account.WithdrawCurrency(bet);
    }

    public int FindOutGamerPoints(Gamer gamer, int newValueForAce)
    {
        PointsForCards pointsForCards = new PointsForCards();
        int gamerPoints = 0;

        foreach (Card card in gamer.GetListOfGamerCards().GetCards())
        {
            int cardValue = pointsForCards.GetPointForCard(card.Rank, newValueForAce);
            gamerPoints += cardValue;
        }

        return gamerPoints;
    }

    public int FindOutDealerPoints(Dealer dealer, int newValueForAce)
    {
        PointsForCards pointsForCards = new PointsForCards();
        int dealerPoints = 0;

        foreach (Card card in dealer.GetListOfDealerCards().GetCards())
        {
            int cardValue = pointsForCards.GetPointForCard(card.Rank, newValueForAce);

            if (card.Rank == "Ace")
            {
                dealerPoints += newValueForAce;
            }
            
            dealerPoints += cardValue;
        }

        return dealerPoints;
    }

    public void DetermineWinners(Gamer gamer, int playerPoints, int dealerPoints, int bet)
    {
        if (dealerPoints > 21 || (playerPoints <= 21 && playerPoints > dealerPoints))
        {
            HandleWin(gamer, bet * 2);
        }
        else if (playerPoints == dealerPoints || playerPoints >= 21)
        {
            HandleWin(gamer, bet);
        }
        else if (playerPoints < dealerPoints && dealerPoints < 21)
        {
            HandleLoss(gamer);
        }
    }

    private void HandleWin(Gamer gamer, int winnings)
    {
        _blackjackCasino.AccrueWinning(gamer, winnings);
    }

    private void HandleLoss(Gamer gamer)
    {
        _blackjackCasino.AccrueLoss(gamer, 0);
    }
}