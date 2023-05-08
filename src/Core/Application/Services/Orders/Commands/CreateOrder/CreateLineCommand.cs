namespace Application.Services.Orders.Commands.CreateOrder;

public class CreateLineCommand
{
    public Guid Id { get; set; }
    public int Qty { get; set; }
}