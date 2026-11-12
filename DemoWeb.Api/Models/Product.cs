namespace SirIthara.Api.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public int ProductTypeId { get; set; }
    public bool Status { get; set; }
}
