using Domain;
using Application.Common.Exceptions;
using Application.Services.Orders.Commands.UpdateOrder;

namespace Application.Common.Extensions;

internal static class StatusExtension
{
    internal static bool IsStatusValid(this string status)
    {
        if (Enum.TryParse<Status>(status, out _))
            return true;
        
        throw new ArgumentException($"Unknown status value: {status}");
    }
    
    internal static bool IsCanChangeStatus(this Status status)
    {
        switch (status)
        {
            case Status.New:
            case Status.AwaitingPayment:
                return true;
            case Status.Paid:
            case Status.HandedOverForDelivery:
            case Status.Delivered:
            case Status.Completed:
                throw new NotCannotBeChanged(nameof(UpdateOrderCommand), status);
            default:
                throw new NotCannotBeChanged(nameof(UpdateOrderCommand), status);
        }
    }

    internal static bool IsCanDelete(this Status status)
    {
        switch (status)
        {
            case Status.New:
            case Status.AwaitingPayment:
            case Status.Paid:
                return true;
            case Status.HandedOverForDelivery:
            case Status.Delivered:
            case Status.Completed:
                return false;
            default:
                return false;
        }
    }
}