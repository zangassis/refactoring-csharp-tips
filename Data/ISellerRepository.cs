using RefactoringAPI.Models;

namespace RefactoringAPI.Data
{
    public interface ISellerRepository
    {
        void CreateSeller(Seller seller);
        void DeleteSeller(Seller seller);
        Task<List<Seller>> GetAllSellers();
        Task<Seller> GetSellerById(Guid id);
        Task<bool> UpdateSeller(Seller seller);
    }
}