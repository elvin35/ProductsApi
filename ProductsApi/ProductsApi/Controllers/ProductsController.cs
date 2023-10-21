using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Repository;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = _mapper.Map<List<ProductsModel>>(await _productsRepository.GetAll());
            return Ok(products);
        }
    }
}
