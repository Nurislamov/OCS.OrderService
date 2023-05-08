namespace Application.Common.Exceptions;

internal class NotZeroException : Exception
{
    internal NotZeroException(string name)
        : base($"Quantity \"{name}\" must not be zero") { }
}