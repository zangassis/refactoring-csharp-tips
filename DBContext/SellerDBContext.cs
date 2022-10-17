using Microsoft.EntityFrameworkCore;
using RefactoringAPI.Models;

namespace RefactoringAPI.DBContext;
public class SellerDBContext : DbContext
{
    public DbSet<Seller>? Sellers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("DataSource=products.db;Cache=Shared");
}

