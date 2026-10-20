using ECommerce.Application.Params;
using ECommerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Specifications
{
    public class ProductSpecifications : BaseSpecifications<Product, int>
    {
        public ProductSpecifications(ProductQueryParams queryParams): 
            base(P => (!queryParams.BrandId.HasValue || P.BrandId == queryParams.BrandId) 
            && (!queryParams.TypeId.HasValue || P.TypeId == queryParams.TypeId)
            && (string.IsNullOrEmpty(queryParams.searchValue) || P.Name.ToLower().Contains(queryParams.searchValue.ToLower())))
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
