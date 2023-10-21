using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.Data;

namespace ProductsApi.Repository;

public interface IProductsRepository
{
    Task<bool> Add(Products product);

    Task<bool> Remove(string name);

    Task<bool> Update(string name,Products product);
    
    Task<List<Products>>GetAll();
}