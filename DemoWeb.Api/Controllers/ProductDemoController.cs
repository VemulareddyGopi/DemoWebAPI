using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SirIthara.Api.Services;

namespace SirIthara.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDemoController(IProductService productService) : ControllerBase
{
    public async Task<IActionResult> GetProducts()
    {
        var products = await productService.GetProducts();
        return Ok(products);
    }
}
