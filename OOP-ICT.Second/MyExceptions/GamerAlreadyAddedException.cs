namespace OOP_ICT.Second.MyExceptions;

public class GamerAlreadyAddedException : Exception
{
    public GamerAlreadyAddedException()
    {
    }

    public GamerAlreadyAddedException(string message) : base(message)
    {
    }
    
}