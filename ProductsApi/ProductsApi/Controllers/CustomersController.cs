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
    
    [HttpPost("AddCustomer")]
    public async Task<IActionResult> AddCustomer(CustomerModel customer)
    {
        var newCustomer = _mapper.Map<Customers>(customer);
        
        await _customersRepository.Add(newCustomer);
        return Ok();
    }
}