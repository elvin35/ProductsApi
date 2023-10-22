namespace ProductsApi.Data;

public class Orders
{
    public int Id { get; set; }
    
    public Customers Customers { get; set; }
    
    public Products Products { get; set; }
}