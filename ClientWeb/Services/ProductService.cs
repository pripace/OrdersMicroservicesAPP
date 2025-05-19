using ClientWeb.DTOs;

namespace ClientWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client) 
        {
            _client = client;
        }
        public Task CreateOrder(List<OrderProductDto> products)
        {
            //agrupar products
            // crear una orden
            //llamar al micros de ordenes para grabar la orden
            throw new NotImplementedException();
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            _client.BaseAddress = new Uri("http://localhost:5155/");

            var response = await _client.GetFromJsonAsync<List<ProductDto>>("api/Product");

            return response ?? new List<ProductDto>();
        }
    }
}
