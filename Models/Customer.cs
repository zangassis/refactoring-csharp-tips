namespace RefactoringAPI.Models;
public class Customer
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public Steps Step  { get; set; }

    public Customer(Guid id, string? name, string? address, Steps step)
    {
        Id = id;
        Name = name;
        Address = address;
        Step = step;
    }
}

