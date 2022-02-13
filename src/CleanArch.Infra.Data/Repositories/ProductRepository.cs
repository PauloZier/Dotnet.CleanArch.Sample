using System;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Repositories;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(long? id)
        {
            #nullable disable 

            var product = await _context.FindAsync<Product>(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            #nullable enable
        }

        public async Task<Product?> FindByIdAsync(long? id)
        {
            return await _context.FindAsync<Product>(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await this._context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> SaveAsync(Product product)
        {
            if (product.Id.HasValue)
                _context.Products.Update(product);
            else
                await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

            return product;
        }
    }
}
