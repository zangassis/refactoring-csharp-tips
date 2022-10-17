namespace RefactoringAPI.Models;

public class OrderWithoutConstructor
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? CustomerId { get; set; }
    public string? ProductId { get; set; }
    public decimal Value { get; set; }
}
