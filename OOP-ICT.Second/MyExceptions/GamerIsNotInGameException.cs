namespace OOP_ICT.Second.MyExceptions;

public class GamerIsNotInGameException : Exception
{
    public GamerIsNotInGameException()
    {
    }

    public GamerIsNotInGameException(string message) : base(message)
    {
    }
}