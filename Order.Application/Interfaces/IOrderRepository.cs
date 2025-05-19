using Order.Domain.Entities;

namespace Order.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(OrderEntity order);
        Task<OrderEntity> GetByIdAsync(int id);
        Task<List<OrderEntity>> GetAllAsync();

    }
}
