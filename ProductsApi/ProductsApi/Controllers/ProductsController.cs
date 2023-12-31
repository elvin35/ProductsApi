﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
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

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = _mapper.Map<List<ProductsModel>>(await _productsRepository.GetAll());
            return Ok(products);
        }

        [HttpPost("AddNewProduct")]
        public async Task<IActionResult> AddProduct(ProductsModel product)
        {
            var newProduct = _mapper.Map<Products>(product);
            if (await _productsRepository.Add(newProduct))
                return Ok($"Product {product.Name} added");
            return BadRequest("This product exist");
        }

        [HttpDelete("RemoveProduct")]
        public async Task<IActionResult> RemoveProduct(string name)
        {
            if (await _productsRepository.Remove(name))
                return Ok($"{name} deleted");
            return BadRequest("Product not found");
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(string productName, [FromBody] UpdateProduct product)
        {
            var updatedProduct = _mapper.Map<Products>(product);
            if (await _productsRepository.Update(productName, updatedProduct))
                return Ok($"{productName} updated");
            return BadRequest("Product not found");
        }
    }
}
