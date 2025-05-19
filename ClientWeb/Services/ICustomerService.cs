using ClientWeb.DTOs;

namespace ClientWeb.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllCustomersAsync();
    }
}
