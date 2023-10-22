namespace ProductsApi.Models;

public class UpdateProduct
{
    [CheckNegative]
    public decimal Price { get; set; } 
    
    public string Description { get; set; }
}