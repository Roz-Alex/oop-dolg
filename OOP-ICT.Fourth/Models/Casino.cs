using OOP_ICT.Second;
using OOP_ICT.Second.AccountFactory;
using OOP_ICT.Second.Accounts;
using OOP_ICT.Second.MyExceptions;
using OOP_ICT.Second.Person;

namespace OOP_ICT.Fourth.Models;

public class Casino
{
    private CasinoAccount _casinoAccount;
    private List<int> _listOfGamers = new List<int>();

    public Casino(CasinoAccount casinoAccount)
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

    public void AccrueLoss(Gamer gamer, int chips)
    {
        if (!_listOfGamers.Contains(gamer.Id))
        {
            throw new GamerIsNotInGameException("Gamer not found in our casino");
        }
        if (chips <= 0)
        {
            throw new NegativeCurrencyException("Loss should be > 0");
        }
        GamerCasinoAccount gamerCasinoAccount = gamer.GamerCasinoAccount;
        gamerCasinoAccount.WithdrawCurrency(chips);
    }
}