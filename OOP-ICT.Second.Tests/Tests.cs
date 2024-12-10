using OOP_ICT.Second.AccountFactory;
using OOP_ICT.Second.Accounts;
using OOP_ICT.Second.Person;
using Xunit;

namespace OOP_ICT.Second;

public class Tests
{
    [Fact]
    public void Gamer_Constructor_InitializesNameAndID()
    {
        string name = "Alice";
        var gamer = new Gamer(name);
        Assert.Equal(name, gamer.Name);
        Assert.Equal(1000, gamer.Id);
    }
    [Fact]
    public void BankAccountTest()
    {
        Gamer gamer = new Gamer("Lisa");
        int id = gamer.Id;
        GamerBankAccountCreator gamerBankAccountCreator = new GamerBankAccountCreator();
        GamerBankAccount gamerBankAccount = (GamerBankAccount)gamerBankAccountCreator.CreateAccount(id);
        Assert.Equal(1000, id);
        Assert.Equal(0, gamerBankAccount.GetBalance());
        gamerBankAccount.AddCurrency(20);
        Assert.True(gamerBankAccount.PossibleBet(10));
    }
    [Fact]
    public void BankCasinoTest()
    {
        Gamer gamer = new Gamer("Lisa");
        int id = gamer.Id;
        GamerCasinoAccountCreator gamerCasinoAccountCreator = new GamerCasinoAccountCreator();
        GamerCasinoAccount gamerCasinoAccount = (GamerCasinoAccount)gamerCasinoAccountCreator.CreateAccount(id);
        Assert.Equal(1000, id);
        Assert.Equal(0, gamerCasinoAccount.GetBalance());
    }
    [Fact]
    public void CasinoTest()
    {
        CasinoAccount casinoAccount = new CasinoAccount(1000);
        Assert.Equal(1000, casinoAccount.GetBalance());
        casinoAccount.AddChips(10);
        Assert.Equal(1010, casinoAccount.GetBalance());
        casinoAccount.WithdrawChips(20);
        Assert.Equal(990, casinoAccount.GetBalance());
    }
    [Fact]
    public void BankTest()
    {
        Bank bank = new Bank();
        Gamer gamer = new Gamer("Dima");
        GamerBankAccount bankAccount = bank.CreateBankAccount(gamer);
        bank.TopUpAccount(gamer, 100);
        Assert.Equal(100, bankAccount.GetBalance());
        bank.WithdrawCurrency(gamer, 10);
        Assert.Equal(90, bankAccount.GetBalance());
        Assert.True(bank.PossibleBet(gamer, 10));
    }
    [Fact]
    public void BlackJackTest()
    {
        CasinoAccount casinoAccount = new CasinoAccount(1000);
        BlackjackCasino blackjackCasino = new BlackjackCasino(casinoAccount);
        Bank bank = new Bank();
        Gamer gamer = new Gamer("Dima");
        GamerBankAccount bankAccount = bank.CreateBankAccount(gamer);
        GamerCasinoAccount gamerCasinoAccount = blackjackCasino.CreateCasinoAccount(gamer);
        ChipsMoneyExchange chipsMoneyExchange = new ChipsMoneyExchange();
        bank.TopUpAccount(gamer, 100);
        blackjackCasino.BuyChips(chipsMoneyExchange, gamer, 10);
        Assert.Equal(90, bankAccount.GetBalance());
        Assert.Equal(10, gamerCasinoAccount.GetBalance());
        blackjackCasino.AccrueWinning(gamer, 5);
        Assert.Equal(15, gamerCasinoAccount.GetBalance());
        blackjackCasino.AccrueLoss(gamer, 1);
        Assert.Equal(14, gamerCasinoAccount.GetBalance());
        blackjackCasino.Blackjack(gamer, 10);
        Assert.Equal(34, gamerCasinoAccount.GetBalance());
    }
}