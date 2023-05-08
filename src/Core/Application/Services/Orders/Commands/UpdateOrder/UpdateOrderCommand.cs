namespace Application.Services.Orders.Commands.UpdateOrder;

public class UpdateOrderCommand
{
    public UpdateOrderCommand() => Lines = new List<UpdateLineCommand>();

    public Guid Id { get; set; }
    public string Status { get; set; } = null!;
    public ICollection<UpdateLineCommand> Lines { get; set; } 
}