using OOP_ICT.Second.Person;

namespace OOP_ICT.Second.Accounts;

public class GamerBankAccount : IAccount<double>
{
    private double _accountBalance;
    private int _gamerId;

    public GamerBankAccount(int gamerId, double accountBalance)
    {
        _gamerId = gamerId;
        _accountBalance = accountBalance;
    }

    public double GetBalance()
    {
        return _accountBalance;
    }

    public int FindOutOwnerOfAccount()
    {
        return _gamerId;
    }

    public void AddCurrency(double money)
    {
        _accountBalance += money;
    }

    public void WithdrawCurrency(double money)
    {
        _accountBalance -= money;
    }

    public bool PossibleBet(double money)
    {
        return money <= _accountBalance;
    }
}