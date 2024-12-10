namespace OOP_ICT.Second.MyExceptions;

public class NegativeCurrencyException : Exception
{
    public NegativeCurrencyException()
    {
    }

    public NegativeCurrencyException(string message) : base(message)
    {
    }
}