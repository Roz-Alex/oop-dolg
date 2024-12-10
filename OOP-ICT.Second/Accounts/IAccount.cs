namespace OOP_ICT.Second.Accounts;

public interface IAccount<T>
{
    T GetBalance();
    void AddCurrency(T currency);
    void WithdrawCurrency(T currency);
    bool PossibleBet(T currency);
}