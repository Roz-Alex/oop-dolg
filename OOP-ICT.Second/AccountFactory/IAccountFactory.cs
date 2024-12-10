using OOP_ICT.Second.Accounts;
using OOP_ICT.Second.Person;

namespace OOP_ICT.Second.AccountFactory;

public interface IAccountFactory<T>
{
    IAccount<T> CreateAccount(int id);
    
}