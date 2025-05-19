using Customer.Domain.Entities;

namespace Customer.Application.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerEntity>> GetAllAsync();
    Task<CustomerEntity?> GetByIdAsync(int id);
    Task AddAsync(CustomerEntity customer);
    Task UpdateAsync(CustomerEntity customer);
    Task DeleteAsync(int id);
}
