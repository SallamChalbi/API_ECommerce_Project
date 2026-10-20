using ECommerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Specifications
{
    public class ProductSpecifications : BaseSpecifications<Product, int>
    {
        public ProductSpecifications(int? brandId, int? typeId): 
            base(P => (!brandId.HasValue || P.BrandId == brandId) && (!typeId.HasValue || P.TypeId == typeId))
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);
        }
        public ProductSpecifications(int id): base(p => p.Id == id)
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);
        }
    }
}
