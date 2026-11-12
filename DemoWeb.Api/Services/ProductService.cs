using SirIthara.Api.Models;
using SirIthara.Api.Reponses;
using Microsoft.EntityFrameworkCore;
namespace SirIthara.Api.Services;

public class ProductService(AppDbContext context, ILogger<ProductService> logger):IProductService
{

    public async Task<List<ProductResponse>> GetProducts()
    {
        var productList = await context.Products.Where(x=>x.Status == true).AsNoTracking()
            .Join(context.ProductTypes.AsNoTracking().Where(x => x.Status == true), p => p.ProductTypeId, pt => pt.ProductTypeId, 
            (p, pt) => new { Product = p, ProductType = pt }).ToListAsync();

        logger.LogInformation("GetProducts Processing");

        var productResponses = productList.Select(item =>
        {
           
            return new ProductResponse
            {
                ProductId = item.Product.ProductId,
                Name = item.Product.Name,
                Price = item.Product.Price,
                Stock = item.Product.Stock,
                Type = item.ProductType ?.Type ?? string.Empty
            };
        }).OrderByDescending(x=>x.Price).ToList();


        var productgroup=productResponses.GroupBy(x => x.Type)
            .Select(g => new
            {
                Type = g.Key,
                Count = g.Count(),
                TotalPrice = g.Sum(x => x.Price),
                AveragePrice = g.Average(x => x.Price)
            }).ToList();


        var maxPrice = await context.Products.MaxAsync(x => x.Price);
        var minPrice = await context.Products.MinAsync(x => x.Price);
        var totalValue = await context.Products.SumAsync(x => x.Price);



        var price = "1200";

        decimal amount  =  Convert.ToDecimal(price);

        logger.LogInformation("Order Responses: {@productResponses}", productResponses);

        return productResponses;
    }
}
