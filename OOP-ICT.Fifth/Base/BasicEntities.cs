using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;
using OOP_ICT.Second;

namespace OOP_ICT.Fifth.Base;

public class BasicEntities
{
    private CasinoAccount _casinoAccount = new CasinoAccount(1000000000);
    private Bank _bank = new Bank();
    private Casino _casino;
    private Dealer _dealer = new Dealer(new CardDeck().GenerateCardDeck());
    public CasinoAccount GetCasinoAccount()
    {
        return _casinoAccount;
    }

    public Bank GetBank()
    {
        return _bank;
    }

    public void CreateCasino()
    {
        _casino = new Casino(_casinoAccount);
    }

    public Casino GetCasino()
    {
        return _casino;
    }

    public Dealer GetDealer()
    {
        return _dealer;
    }
}