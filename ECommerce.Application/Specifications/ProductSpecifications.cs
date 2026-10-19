using ECommerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Specifications
{
    public class ProductSpecifications : BaseSpecifications<Product, int>
    {
        public ProductSpecifications()
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);
        }
    }
}
