using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.Data;

namespace ProductsApi.Repository;

public class CustomersRepository : ICustomersRepository
{
    private readonly ProductsApiDbContext _context;
    
    public CustomersRepository(ProductsApiDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> Add(Customers customer)
    {
        await _context.AddAsync(customer);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Remove(string name)
    {
        throw new System.NotImplementedException();
    }

    public async Task<decimal> CheckBalance(string name)
    {
        throw new System.NotImplementedException();
    }

    public async Task BuyProduct(string customerName, string productName)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<Customers>> ShowAllCustomers()
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<Products>> CheckCustomerProducts(string name)
    {
        throw new System.NotImplementedException();
    }
}