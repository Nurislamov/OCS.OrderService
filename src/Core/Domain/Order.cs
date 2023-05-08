namespace Domain;

/// <summary>
/// Order
/// </summary>
public sealed class Order
{
    public Order() => Lines = new List<Line>();
    
    public Guid Id { get; init; }
    public Status Status { get; set; }
    public DateTime CreatedDateTime { get; init; }
    
    public ICollection<Line> Lines { get; set; }
}