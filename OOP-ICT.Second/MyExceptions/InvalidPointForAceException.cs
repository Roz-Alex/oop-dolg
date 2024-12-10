namespace OOP_ICT.Second.MyExceptions;

public class InvalidPointForAceException : Exception
{
    public InvalidPointForAceException()
    {
    }

    public InvalidPointForAceException(string message) : base(message)
    {
    }
}