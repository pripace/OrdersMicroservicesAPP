using Product.Domain.Entities;

namespace Order.Application.Contracts
{
    public interface IProductRepository
    {
        Task<ProductEntity?> GetByIdAsync(int id);
        Task UpdateProductAsync(ProductEntity product);
    }
}
