using Microsoft.AspNetCore.Mvc;
using ProductsApi.Repository;
using System.Runtime.CompilerServices;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
               _productsRepository = productsRepository;
        }
    }
}
