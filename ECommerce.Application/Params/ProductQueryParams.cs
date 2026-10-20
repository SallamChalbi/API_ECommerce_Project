using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Params
{
    public class ProductQueryParams
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? searchValue { get; set; }

        public ProductSortingOptions sort { get; set; } = ProductSortingOptions.None;
    }
}
