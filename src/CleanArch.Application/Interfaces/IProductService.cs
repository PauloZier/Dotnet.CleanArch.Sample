using System;
using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProductsAsync();
        Task<ProductViewModel?> FindByIdAsync(long? id);
        Task<ProductViewModel> SaveAsync(ProductViewModel product);
        Task DeleteByIdAsync(long? id);
    }
}
