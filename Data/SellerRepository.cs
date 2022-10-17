using Microsoft.EntityFrameworkCore;
using RefactoringAPI.DBContext;
using RefactoringAPI.Models;

namespace RefactoringAPI.Data;
public class SellerRepository : ISellerRepository
{
    private readonly SellerDBContext _dbContext;

    public SellerRepository(SellerDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Seller>> GetAllSellers() => await _dbContext.Sellers.ToListAsync();
    public async Task<Seller> GetSellerById(Guid id) =>
        await _dbContext.Sellers.FirstOrDefaultAsync(s => s.Id == id);

    public async void CreateSeller(Seller seller)
    {
        await _dbContext.AddAsync(seller);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> UpdateSeller(Seller seller)
    {
        var sellerEntity = await _dbContext.Sellers.FirstOrDefaultAsync(s => s.Id == seller.Id);
        if (sellerEntity is null)
            return false;

        _dbContext.Entry(sellerEntity).CurrentValues.SetValues(seller);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public void DeleteSeller(Seller seller) => _dbContext.Remove(seller);
}
