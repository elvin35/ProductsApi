namespace ProductsApi.Models;

public class CustomerModel
{
    [Newtonsoft.Json.JsonIgnore]
    public int Id { get; set; }
    
    public string Name { get; set; }

    [CheckNegative]
    public decimal Balance { get; set; }
}