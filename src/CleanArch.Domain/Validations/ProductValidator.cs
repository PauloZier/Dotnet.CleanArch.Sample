using System;
using CleanArch.Domain.Entities;
using FluentValidation;

namespace CleanArch.Domain.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(150).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(5).MaximumLength(250).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0).NotNull();
        }
    }
}
