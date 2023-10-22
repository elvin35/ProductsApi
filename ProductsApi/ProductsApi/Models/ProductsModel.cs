namespace ProductsApi.Models;

public class ProductsModel
{
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public int Id { get; set; }

    public string Name { get; set; }

    [CheckNegative]
    public decimal Price { get; set; } 
    
    public string Description { get; set; }
}