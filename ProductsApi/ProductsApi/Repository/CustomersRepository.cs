using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        var customer = await _context.Customers.SingleOrDefaultAsync(customer => customer.Name == name);
        if (customer == null)
            return false;
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<decimal> CheckBalance(string name)
    {
        var customer = await _context.Customers.SingleOrDefaultAsync(customer => customer.Name == name);
        if (customer == null)
            throw new NotImplementedException("Customer not exist");
        return customer.Balance;
    }

    public async Task BuyProduct(string customerName, string productName)
    {
        var customer = await _context.Customers.SingleOrDefaultAsync(customer => customer.Name == customerName);
        var product = await _context.Products.SingleOrDefaultAsync(product => product.Name == productName);
        if (customer.Balance >= product.Price)
        {
            customer.Balance = customer.Balance - product.Price;
            var order = new Orders() { Customers = customer, Products = product };
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new NotImplementedException("Not enough money");
        }
    }

    public async Task<List<Customers>> ShowAllCustomers()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<List<Products>> CheckCustomerProducts(string customerName)
    {
        var proudcts = await _context.Orders.Where(orders => orders.Customers.Name == customerName)
            .Select(orders => orders.Products).ToListAsync();
        return proudcts;
    }
}