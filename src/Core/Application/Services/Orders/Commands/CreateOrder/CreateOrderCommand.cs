namespace Application.Services.Orders.Commands.CreateOrder;

public class CreateOrderCommand
{
    public CreateOrderCommand() => Lines = new List<CreateLineCommand>();
    
    public Guid Id { get; set; }
    public ICollection<CreateLineCommand> Lines { get; set; } 
}