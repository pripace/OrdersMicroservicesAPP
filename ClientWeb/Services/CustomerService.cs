using ClientWeb.DTOs;

namespace ClientWeb.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;

        public CustomerService(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            _client.BaseAddress = new Uri("http://localhost:5105/");

            var response = await _client.GetFromJsonAsync<List<CustomerDto>>("api/Customer");

            return response ?? new List<CustomerDto>();
        }
    }
}
