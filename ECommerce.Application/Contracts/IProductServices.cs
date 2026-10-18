using ECommerce.Application.Common;
using ECommerce.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Contracts
{
    public interface IProductServices
    {
        Task<Result<IReadOnlyList<ProductDTO>>> GetAllProductsAsync(CancellationToken ct = default);
        Task<Result<IReadOnlyList<BrandDTO>>> GetAllProductBrandsAsync(CancellationToken ct = default);
        Task<Result<IReadOnlyList<TypeDTO>>> GetAllProductTypesAsync(CancellationToken ct = default);
        Task<Result<ProductDTO>> GetProductByIdAsync(int id, CancellationToken ct = default);
    }
}
