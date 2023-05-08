using Application.Services.Orders.Commands.CreateOrder;
using Application.Services.Orders.Commands.UpdateOrder;


namespace Application.Common.Extensions;

internal static class OrderCommandExtensions
{
    internal static bool IsCreateOrderValid(this CreateOrderCommand command)
    {
        return command.Lines.IsLinesNotEmpty() && command.Lines.IsQuantityNotZero();
    }

    internal static bool IsUpdateOrderValid(this UpdateOrderCommand command)
    {
        if (!command.Status.IsStatusValid()) 
            return false;
        
        return command.Lines.IsLinesNotEmpty() && command.Lines.IsQuantityNotZero();
    }
}