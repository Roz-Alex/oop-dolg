using OOP_ICT.Second.Accounts;

namespace OOP_ICT.Second.AccountFactory;

public class GamerCasinoAccountCreator : IAccountFactory<int>
{
    private const int InitialBalance = 0;

    public IAccount<int> CreateAccount(int gamerId)
    {
        return new GamerCasinoAccount(gamerId, InitialBalance);
    }
}