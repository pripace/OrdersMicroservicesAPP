using ClientWeb.DTOs;

namespace ClientWeb.Services
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllOrdersAsync();
    }
}



