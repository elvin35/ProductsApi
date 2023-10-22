using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Repository;

namespace ProductsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomersRepository _customersRepository;

    public CustomersController(ICustomersRepository customersRepository)
    {
        _customersRepository = customersRepository;
    }
    
}