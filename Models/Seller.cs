namespace RefactoringAPI.Models;

public class Seller
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? ContactEmail { get; set; }
    public bool SmallSeller { get; set; }

    public Seller(string? name, string? contactEmail, bool smallSeller)
    {
        Name = name;
        ContactEmail = contactEmail;
        SmallSeller = smallSeller;
    }

    public static List<Seller> AllSellers()
    {
        var bigSeller = new Seller("BigSeller", "bigseller@mail.com", false);
        var smallSeller = new Seller("SmallSeller", "smallseller@mail.com", true);
        return new List<Seller>() { bigSeller, smallSeller };
    }
}
