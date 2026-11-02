using ECommerce.Application.Common;
using ECommerce.Application.DTOs.Products;
using ECommerce.Application.Params;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Contracts
{
    public interface IProductServices
    {
        Task<Result<PaginatedResult<ProductDTO>>> GetAllProductsAsync(ProductQueryParams queryParams, CancellationToken ct = default);
        Task<Result<IReadOnlyList<BrandDTO>>> GetAllProductBrandsAsync(CancellationToken ct = default);
        Task<Result<IReadOnlyList<TypeDTO>>> GetAllProductTypesAsync(CancellationToken ct = default);
        Task<Result<ProductDTO>> GetProductByIdAsync(int id, CancellationToken ct = default);
    }
}
