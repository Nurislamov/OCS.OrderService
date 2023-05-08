namespace Application.Common.Exceptions;

internal class NotFoundException : Exception
{
    internal NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) not found") { }
    
    internal NotFoundException(string name)
        : base($"Entity \"{name}\" not found") { }
}