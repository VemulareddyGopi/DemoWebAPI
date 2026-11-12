namespace SirIthara.Api.Reponses;

public class ProductResponse
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Type { get; set; } = string.Empty;

}
