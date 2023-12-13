using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.Data;

namespace ProductsApi.Repository;

public interface ICustomersRepository
{
    Task<bool> Add(Customers customer);

    Task<bool> Remove(int customerId);

    Task<decimal> CheckBalance(int customerId);

    Task BuyProduct(int customerId,string productName);

    Task<List<Customers>> ShowAllCustomers();
    
    Task<List<Products>> CheckCustomerProducts(int customerId);
}