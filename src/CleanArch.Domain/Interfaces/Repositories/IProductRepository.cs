using System;
using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product?> FindByIdAsync(long? id);
        Task<Product> SaveAsync(Product product);
        Task DeleteByIdAsync(long? id);
    }
}
