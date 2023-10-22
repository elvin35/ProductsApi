using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Models;
using ProductsApi.Repository;

namespace ProductsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomersRepository _customersRepository;
    private readonly IMapper _mapper;
    
    public CustomersController(ICustomersRepository customersRepository, IMapper mapper)
    {
        _customersRepository = customersRepository;
        _mapper = mapper;

    }
    
    [HttpGet("ShowAllCustomers")]
    public async Task<IActionResult> ShowAllCustomers()
    {
        return Ok(await _customersRepository.ShowAllCustomers());
    }
    
    [HttpPost("AddCustomer")]
    public async Task<IActionResult> AddCustomer(CustomerModel customer)
    {
        var newCustomer = _mapper.Map<Customers>(customer);
        
        await _customersRepository.Add(newCustomer);
        return Ok();
    }

    [HttpDelete("RemoveCustomer")]
    public async Task<IActionResult> RemoveCustomer(string name)
    {
        return Ok(await _customersRepository.Remove(name));
    }

    [HttpPost("BuyProductByName")]
    public async Task<IActionResult> BuyProduct(string customerName, string productName)
    {
        await _customersRepository.BuyProduct(customerName, productName);
        return Ok();
    }

    [HttpGet("GetCustomerProducts")]
    public async Task<IActionResult> GetCustomerProducts(string customerName)
    {
        var productsList = await _customersRepository.CheckCustomerProducts(customerName);
        return Ok(productsList);
    }

    [HttpGet("CheckBalance")]
    public async Task<IActionResult> CheckBalance(string name)
    {
        var balance = await _customersRepository.CheckBalance(name);
        return Ok(balance);
    }
}