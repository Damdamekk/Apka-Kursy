namespace Apka_Kursy.Exceptions;

public class DatabaseSavingException : Exception
{
    public DatabaseSavingException(string message) : base(message)
    {
    }
}