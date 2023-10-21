using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Data;

public class ProductsApiDbContext : DbContext
{
    public ProductsApiDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Products> Products { get; set; }
}