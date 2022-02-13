using System;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.Mapping.SQLite
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Price).HasPrecision(10, 2).IsRequired();
        }
    }
}
