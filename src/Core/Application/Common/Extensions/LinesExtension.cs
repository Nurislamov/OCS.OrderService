using Application.Common.Exceptions;
using Application.Services.Orders.Commands.CreateOrder;
using Application.Services.Orders.Commands.UpdateOrder;

namespace Application.Common.Extensions;

internal static class LinesExtension
{
    internal static bool IsQuantityNotZero<T>(this IEnumerable<T> lines)
    {
        try
        {
            if (typeof(T) == typeof(CreateLineCommand))
            {
                var create = (ICollection<CreateLineCommand>)lines;
                if (create.All(line => line.Qty >= 1))
                    return true;
                
                throw new NotZeroException(nameof(CreateLineCommand));
            }

            if (typeof(T) == typeof(UpdateLineCommand))
            {
                var update = (ICollection<UpdateLineCommand>)lines;
                if (update.All(line => line.Qty >= 1))
                    return true;
                
                throw new NotZeroException(nameof(UpdateLineCommand));
            }
        }
        catch (Exception e)
        {
            throw new InvalidOperationException(e.Message);
        }
        return false;
    }
    
    internal static bool IsLinesNotEmpty<T>(this IEnumerable<T> lines)
    {
        if (lines.Any())
            return true;

        throw new NotFoundException(nameof(CreateLineCommand));
    }

    private static Type GetType<T>(T type)
    {
        try
        {
            if (typeof(T) == typeof(CreateLineCommand)) return typeof(CreateLineCommand);
            if (typeof(T) == typeof(UpdateLineCommand)) return typeof(UpdateLineCommand);
        }
        catch (Exception e)
        {
            throw new InvalidOperationException(e.Message);
        }
        return null!;
    }
}