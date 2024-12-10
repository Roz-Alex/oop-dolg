using OOP_ICT.Second.Person;

namespace OOP_ICT.Second.Accounts;

public class GamerCasinoAccount : IAccount<int>
{
    private int _chipsAmount;
    private int _gamerId;

    public GamerCasinoAccount(int gamerId, int accountBalance)
    {
        _gamerId = gamerId;
        _chipsAmount = accountBalance;
    }

    public int GetBalance()
    {
        return _chipsAmount;
    }

    public void AddCurrency(int chips)
    {
        _chipsAmount += chips;
    }

    public void WithdrawCurrency(int chips)
    {
        _chipsAmount -= chips;
    }

    public bool PossibleBet(int chips)
    {
        return chips <= _chipsAmount;
    }
}