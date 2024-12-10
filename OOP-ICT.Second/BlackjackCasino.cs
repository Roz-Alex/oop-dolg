using OOP_ICT.Second.AccountFactory;
using OOP_ICT.Second.Accounts;
using OOP_ICT.Second.Person;

namespace OOP_ICT.Second;

public class BlackjackCasino
{
    private CasinoAccount _casinoAccount;
    private List<int> _listOfGamers = new List<int>();

    public BlackjackCasino(CasinoAccount casinoAccount)
    {
        _casinoAccount = casinoAccount;
    }

    public GamerCasinoAccount CreateCasinoAccount(Gamer gamer)
    {
        int id = gamer.Id;
        GamerCasinoAccountCreator casinoAccountCreator = new GamerCasinoAccountCreator();
        GamerCasinoAccount newGamerCasinoAccount = (GamerCasinoAccount)casinoAccountCreator.CreateAccount(id);
        gamer.GamerCasinoAccount = newGamerCasinoAccount;
        _listOfGamers.Add(id);
        
        return newGamerCasinoAccount;
    }

    public void BuyChips(ChipsMoneyExchange chipsMoneyExchange, Gamer gamer, int money)
    {
        chipsMoneyExchange.BuyChips(gamer, money);
    }


    public void AccrueWinning(Gamer gamer, int chips)
    {
        GamerCasinoAccount gamerCasinoAccount = gamer.GamerCasinoAccount;
        gamerCasinoAccount.AddCurrency(chips);
    }

    public void AccrueLoss(Gamer gamer, int chips)
    {
        GamerCasinoAccount gamerCasinoAccount = gamer.GamerCasinoAccount;
        gamerCasinoAccount.WithdrawCurrency(chips);
    }

    public void Blackjack(Gamer gamer, int chips)
    {
        GamerCasinoAccount gamerCasinoAccount = gamer.GamerCasinoAccount;
        int winning = chips * 2;
        _casinoAccount.WithdrawChips(winning);
        gamerCasinoAccount.AddCurrency(winning);
    }
}