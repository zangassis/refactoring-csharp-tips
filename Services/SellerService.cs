using RefactoringAPI.DBContext;
using RefactoringAPI.Models;

namespace RefactoringAPI.Services;
public class SellerService
{
    private readonly SellerDBContext _context;

    public SellerService(SellerDBContext context)
    {
        _context = context;
    }

    #region 1. Foreach to LINQ
    private void FirstExample()
    {
        var sellers = Seller.AllSellers();

        // Before refactoring
        var smallSellers = new List<Seller>();

        foreach (var seller in sellers)
        {
            if (seller.SmallSeller)
            {
                smallSellers.Add(seller);
            }
        }

        // After refactoring
        var smallSellersRefactored = (from seller in sellers where seller.SmallSeller select seller).ToList();
        // or
        var smallSellersRefactoredCall = (sellers.Where(seller => seller.SmallSeller)).ToList();
    }
    #endregion

    #region 2. Assigning responsibilities

    // Before refactoring
    public string CreateSeller(Seller seller)
    {
        var sellers = _context.Sellers;

        string requiredFieldsMessage = string.Empty;

        if (string.IsNullOrEmpty(seller.Name))
        {
            requiredFieldsMessage += "Name is required";
        }
        if (string.IsNullOrEmpty(seller.ContactEmail))
        {
            requiredFieldsMessage += "Email is mandatory";
        }
        if (!string.IsNullOrEmpty(requiredFieldsMessage))
            return requiredFieldsMessage;

        if (sellers.Contains(seller))
            return "Seller already exists";

        _context.Add(seller);
        _context.SaveChanges();
        return "Success";
    }

    // After refactoring
    public string CreateSellerProcess(Seller seller)
    {
        bool sellerAlreadyExists = SellerAlreadyExistsVerify(seller);

        if (sellerAlreadyExists)
            return "Seller already exists";

        string requiredFieldsMessage = ValidateFields(seller);

        if (!string.IsNullOrEmpty(requiredFieldsMessage))
            return requiredFieldsMessage;

        CreateNewSeller(seller);
        return "Success";
    }

    public bool SellerAlreadyExistsVerify(Seller seller)
    {
        var sellers = Seller.AllSellers();

        return sellers.Contains(seller);
    }

    public string ValidateFields(Seller seller)
    {
        string requiredFieldsMessage = string.Empty;

        if (string.IsNullOrEmpty(seller.Name))
        {
            requiredFieldsMessage += "Name is required";
        }
        if (string.IsNullOrEmpty(seller.ContactEmail))
        {
            requiredFieldsMessage += "Email is mandatory";
        }
        return requiredFieldsMessage;
    }

    public void CreateNewSeller(Seller seller)
    {
        _context.Add(seller);
        _context.SaveChanges();
    }
    #endregion

    #region 3. Synchronous to Asynchronous

    // Sync example
    public void UpdateSellers(Seller seller)
    {
        var sellerEntity = _context.Sellers.Find(seller.Id);

        _context.Entry(sellerEntity).CurrentValues.SetValues(seller);
    }

    // Async example
    public async void UpdateSellersAsync(Seller seller)
    {
        var sellerEntity = await _context.Sellers.FindAsync(seller.Id);

        _context.Entry(sellerEntity).CurrentValues.SetValues(seller);

        _context.SaveChangesAsync();
    }

    #endregion

    #region 4. Generating constructors

    public void OrderProcess()
    {
        var orderWithoutConstructor = new OrderWithoutConstructor()
        {
            CustomerId = "14797513080",
            ProductId = "p69887424099",
            Value = 100
        };

        var orderWithConstructor = new OrderWithConstructor("14797513080", "p69887424099", 100);
    }

    #endregion

    #region 5. Eliminating the if and else chain

    public void CustomerProcess(Customer customer)
    {
        if (customer.Step == Steps.Start)
        {
            //Do something 
        }
        if (customer.Step == Steps.InsertPhoneNumber)
        {
            //Do something 
        }
        if (customer.Step == Steps.PhoneNumberOrEmailToVerify)
        {
            //Do something 
        }
        if (customer.Step == Steps.VerifyToken)
        {
            //Do something 
        }
        if (customer.Step == Steps.DownloadApp)
        {
            //Do something 
        }
        if (customer.Step == Steps.WithLogin)
        {
            //Do something 
        }
        if (customer.Step == Steps.Finished)
        {
            //Do something 
        }

        switch (customer.Step)
        {
            case Steps.Start:
                //Do something 
                break;
            case Steps.InsertPhoneNumber:
                //Do something 
                break;
            case Steps.PhoneNumberOrEmailToVerify:
                //Do something 
                break;
            case Steps.VerifyToken:
                //Do something 
                break;
            case Steps.DownloadApp:
                //Do something 
                break;
            case Steps.WithLogin:
                //Do something 
                break;
            case Steps.Finished:
                //Do something 
                break;
            default:
                //Do something 
                break;
        }
    }

    #endregion

    #region 7. Eliminating unnecessary variables

    //Before refactoring
    public bool SmallSellerVerify(List<Seller> sellers)
    {
        var result = false;

        foreach (var seller in sellers)
        {
            if (seller.SmallSeller == true)
            {
                result = true;
            }
            else
            {
                result = false;
            }
        }
        return result;
    }

    //After refactoring
    //Using Any() and ternary operator (?)
    public bool SmallSellerVerifyRefactored(List<Seller> sellers) => sellers.Any(s => s.SmallSeller) ? true : false;

    //Using only Any()
    public bool SmallSellerVerifyRefactoredTwo(List<Seller> sellers) => sellers.Any(s => s.SmallSeller);

    #endregion

    #region 8. Renaming efficiently

    public void SellerProcess()
    {
        var allSmallSellers = _context.Sellers.Where(s => s.SmallSeller).ToList();

        if (!allSmallSellers.Any())
            Console.WriteLine("The list does not contain small sellers");
        else
            ProcessSmallSellers(allSmallSellers);
    }

    private void ProcessSmallSellers(List<Seller> allSmallSellers)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region 10. Generating methods

    public void GeneratingMethod()
    {
        string sellerName = string.Empty;

        bool verify = ValidateSellerName(sellerName);
    }

    private bool ValidateSellerName(string sellerName)
    {
        throw new NotImplementedException();
    }

    #endregion
}