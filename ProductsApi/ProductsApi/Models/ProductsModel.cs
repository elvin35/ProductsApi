using System.Text.Json.Serialization;

namespace ProductsApi.Models;

public class ProductsModel
{
    [JsonIgnore]
    public int Id { get; set; }

    public string Name { get; set; }

    [CheckNegative]
    public decimal Price { get; set; } 
    
    public string Description { get; set; }
}