using ECommerce.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name).IsRequired().HasMaxLength(50);
            builder.Property(P => P.PictureUrl).IsRequired().HasMaxLength(200);
            builder.Property(P => P.Description).IsRequired().HasMaxLength(500);
            builder.Property(P => P.Price).HasColumnType("decimal(10,2)");
        }
    }
}
