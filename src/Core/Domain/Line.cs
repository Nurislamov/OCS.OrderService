namespace Domain;

/// <summary>
/// Order line
/// </summary>
public class Line
{
    public long Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
}