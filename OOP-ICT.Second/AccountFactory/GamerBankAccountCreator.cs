using OOP_ICT.Second.Accounts;
using OOP_ICT.Second.Person;

namespace OOP_ICT.Second.AccountFactory;

public class GamerBankAccountCreator : IAccountFactory<double>
{
    private const int InitialBalance = 0;

    public IAccount<double> CreateAccount(int gamerId)
    {
        return new GamerBankAccount(gamerId, InitialBalance);
    }
}