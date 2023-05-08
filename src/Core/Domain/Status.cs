namespace Domain;

/// <summary>
/// Order status
/// </summary>
public enum Status
{
    New = 1,
    AwaitingPayment = 2,
    Paid = 3,
    HandedOverForDelivery = 4,
    Delivered = 5,
    Completed = 6
}