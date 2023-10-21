using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsApiDbContext _context;

        public ProductsRepository(ProductsApiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Products product)
        {
            var names = await _context.Products.Select(product => product.Name).ToListAsync();
            foreach (var name in names)
            {
                if (product.Name == name)
                {
                    return false;
                }
            }
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Products>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> Remove(string name)
        {
            var product = await _context.Products.SingleOrDefaultAsync(product => product.Name == name);
            if (product == null) { return false; }
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> Update(string name, Products product)
        {
            
        }
    }
}
