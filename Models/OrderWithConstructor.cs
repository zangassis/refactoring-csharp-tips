namespace RefactoringAPI.Models;
public class OrderWithConstructor
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? CustomerId { get; set; }
    public string? ProductId { get; set; }
    public decimal Value { get; set; }

    public OrderWithConstructor(string? customerId, string? productId, decimal value)
    {
        CustomerId = customerId;
        ProductId = productId;
        Value = value;
    }
}
