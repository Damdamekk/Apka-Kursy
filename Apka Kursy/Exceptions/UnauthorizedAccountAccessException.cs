namespace Apka_Kursy.Exceptions;

public class UnauthorizedAccountAccessException : Exception
{
    public UnauthorizedAccountAccessException(string message) : base(message)
    {

    }
}