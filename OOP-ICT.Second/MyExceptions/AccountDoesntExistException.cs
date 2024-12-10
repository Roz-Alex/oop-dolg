namespace OOP_ICT.Second.MyExceptions;

public class AccountNotFoundException : Exception
{
    public AccountNotFoundException()
    {
    }

    public AccountNotFoundException(string message) : base(message)
    {
    }
}