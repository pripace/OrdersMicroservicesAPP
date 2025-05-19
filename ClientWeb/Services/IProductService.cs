using ClientWeb.DTOs;

namespace ClientWeb.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProductsAsync();

        Task CreateOrder(List<OrderProductDto> products);
    }
}
