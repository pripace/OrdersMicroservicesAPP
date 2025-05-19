using ClientWeb.DTOs;

namespace ClientWeb.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;
        public OrderService(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            _client.BaseAddress = new Uri("http://localhost:5199/");

            var response = await _client.GetFromJsonAsync<List<OrderDto>>("api/Order");

            return response ?? new List<OrderDto>();
        }
    }
}
