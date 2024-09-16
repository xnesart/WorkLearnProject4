namespace WorkLearnProject4.Core.Exceptions;

public class CustomValidationException : Exception
{
    public CustomValidationException(string message) : base(message)
    {
    }
}