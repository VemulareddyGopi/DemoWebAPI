using SirIthara.Api.Reponses;

namespace SirIthara.Api.Services;

public interface IProductService
{
    Task<List<ProductResponse>> GetProducts();
}
