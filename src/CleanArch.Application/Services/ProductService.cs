using System;
using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Repositories;
using FluentValidation;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<Product> _validator;

        public ProductService(
            IProductRepository repository, 
            IMapper mapper, 
            AbstractValidator<Product> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task DeleteByIdAsync(long? id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<ProductViewModel?> FindByIdAsync(long? id)
        {
            var product = await _repository.FindByIdAsync(id);
            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
        {
            var products = await _repository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public async Task<ProductViewModel> SaveAsync(ProductViewModel product)
        {
            #nullable disable

            var mapProduct = _mapper.Map<Product>(product);
            await _validator.ValidateAndThrowAsync(mapProduct);
            await _repository.SaveAsync(mapProduct);
            return _mapper.Map<ProductViewModel>(mapProduct);

            #nullable enable
        }
    }
}
