using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Order.Application.Contracts;
using Product.Domain.Entities;

namespace Order.Infrastructure.ExternalServices
{
    public class ProductRepositoryHttp : IProductRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductRepositoryHttp> _logger;

        public ProductRepositoryHttp(HttpClient httpClient, ILogger<ProductRepositoryHttp> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ProductEntity?> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ProductEntity>($"/api/Product/{id}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener producto con ID {ProductId}", id);
                return null;
            }
        }

        public async Task UpdateProductAsync(ProductEntity product)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"/api/Product/{product.Id}", product);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("No se pudo actualizar el producto ID {ProductId}. Código: {StatusCode}", product.Id, response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el producto ID {ProductId}", product.Id);
            }
        }
    }
}
