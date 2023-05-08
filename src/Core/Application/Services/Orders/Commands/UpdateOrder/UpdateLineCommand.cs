namespace Application.Services.Orders.Commands.UpdateOrder;

public class UpdateLineCommand
{
    public Guid Id { get; set; }
    public int Qty { get; set; }
}