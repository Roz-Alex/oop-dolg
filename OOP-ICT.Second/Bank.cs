using OOP_ICT.Second.AccountFactory;
using OOP_ICT.Second.Accounts;
using OOP_ICT.Second.MyExceptions;
using OOP_ICT.Second.Person;

namespace OOP_ICT.Second;

public class Bank
{
    private List<int> _listOfUsers;

    public Bank()
    {
        _listOfUsers = new List<int>();
    }

    public GamerBankAccount CreateBankAccount(Gamer gamer)
    {
        int id = gamer.Id;
        GamerBankAccountCreator gamerBankAccountCreator = new GamerBankAccountCreator();
        GamerBankAccount newGamerBankAccount = (GamerBankAccount)gamerBankAccountCreator.CreateAccount(id);
        gamer.GamerBankAccount = newGamerBankAccount;
        if (_listOfUsers.Contains(id))
        {
            throw new GamerAlreadyAddedException("This account is already registered");
        }
        _listOfUsers.Add(id);

        return newGamerBankAccount;
    }

    public void TopUpAccount(Gamer gamer, double value)
    {
        if (gamer.GamerBankAccount == null)
        {
            throw new AccountNotFoundException("There is no bank account for this gamer");
        }
        
        if (value < 0)
        {
            throw new NegativeCurrencyException("Currency should be >= 0");
        }
        GamerBankAccount gamerBankAccount = gamer.GamerBankAccount;
        gamerBankAccount.AddCurrency(value);
    }

    public void WithdrawCurrency(Gamer gamer, int currency)
    {
        if (gamer.GamerBankAccount == null)
        {
            throw new AccountNotFoundException("There is no bank account for this gamer");
        }

        if (currency < 0)
        {
            throw new NegativeCurrencyException("Currency should be >= 0");
        }
        GamerBankAccount gamerBankAccount = gamer.GamerBankAccount;
        gamerBankAccount.WithdrawCurrency(currency);
    }

    public bool PossibleBet(Gamer gamer, int bet)
    {
        if (gamer.GamerBankAccount == null)
        {
            throw new AccountNotFoundException("There is no bank account for this gamer");
        }

        if (bet < 0)
        {
            throw new NegativeCurrencyException("Currency should be >= 0");
        }
        GamerBankAccount gamerBankAccount = gamer.GamerBankAccount;
        return gamerBankAccount.PossibleBet(bet);
    }
}