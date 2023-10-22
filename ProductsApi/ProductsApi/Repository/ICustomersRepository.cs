using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.Data;

namespace ProductsApi.Repository;

public interface ICustomersRepository
{
    Task<bool> Add(Customers customer);

    Task<bool> Remove(string name);

    Task<decimal> CheckBalance(string name);

    Task BuyProduct(string customerName,string productName);

    Task<List<Customers>> ShowAllCustomers();
    
    Task<List<Products>> CheckCustomerProducts(string name);
}