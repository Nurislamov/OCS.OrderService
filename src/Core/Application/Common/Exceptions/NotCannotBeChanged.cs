namespace Application.Common.Exceptions;

internal class NotCannotBeChanged : Exception
{
    internal NotCannotBeChanged(string name, object status)
        : base($"Order \"{name}\" not cannot be changed, status \"{status}\"") { }
}