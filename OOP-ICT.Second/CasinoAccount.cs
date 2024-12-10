namespace OOP_ICT.Second;

public class CasinoAccount
{
    private int _balance;

    public CasinoAccount(int balance)
    {
        _balance = balance;
    }

    public int GetBalance()
    {
        return _balance;
    }

    public void WithdrawChips(int chips)
    {
        _balance -= chips;
    }

    public void AddChips(int chips)
    {
        _balance += chips;
    }
}