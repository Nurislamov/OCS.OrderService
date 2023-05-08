namespace Application.Common.Exceptions;

internal class NotCannotBeDeleted : Exception
{
    internal NotCannotBeDeleted(string name, object status)
        : base($"Order \"{name}\" not cannot be deleted, status \"{status}\"") { }
}