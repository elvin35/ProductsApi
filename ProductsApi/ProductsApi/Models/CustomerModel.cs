using System.Text.Json.Serialization;

namespace ProductsApi.Models;

public class CustomerModel
{
    [JsonIgnore]
    public int Id { get; set; }
    
    public string Name { get; set; }

    [CheckNegative]
    public decimal Balance { get; set; }
}