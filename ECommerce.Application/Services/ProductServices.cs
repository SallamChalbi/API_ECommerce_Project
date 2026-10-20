using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.Contracts;
using ECommerce.Application.DTOs.Products;
using ECommerce.Application.Specifications;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<IReadOnlyList<BrandDTO>>> GetAllProductBrandsAsync(CancellationToken ct = default)
        {
            var brands = await unitOfWork.GetRepository<ProductsBrand, int>().GetAllAsync(ct);
            var mappedBrands = mapper.Map<IReadOnlyList<ProductsBrand>, IReadOnlyList<BrandDTO>>(brands);
            return Result<IReadOnlyList<BrandDTO>>.Ok(mappedBrands);
        }

        public async Task<Result<IReadOnlyList<ProductDTO>>> GetAllProductsAsync(CancellationToken ct = default)
        {
            // static
            //var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync(ct);
            // with specification pattern
            var spec = new ProductSpecifications();
            var products = await unitOfWork.GetRepository<Product, int>().GetAllWithSpecificationsAsync(spec, ct);
            var mappedProducts = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products);
            return Result<IReadOnlyList<ProductDTO>>.Ok(mappedProducts);
        }

        public async Task<Result<IReadOnlyList<TypeDTO>>> GetAllProductTypesAsync(CancellationToken ct = default)
        {
            var types = await unitOfWork.GetRepository<ProductsType, int>().GetAllAsync(ct);
            var mappedTypes = mapper.Map<IReadOnlyList<ProductsType>, IReadOnlyList<TypeDTO>>(types);
            return Result<IReadOnlyList<TypeDTO>>.Ok(mappedTypes);
        }

        public async Task<Result<ProductDTO>> GetProductByIdAsync(int id, CancellationToken ct = default)
        {
            // static
            //var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(id, ct);
            // with specification pattern
            var spec = new ProductSpecifications(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetByIdWithSpecificationsAsync(spec, ct);
            
            if(product is null)
                return Result<ProductDTO>.Fail(Error.NotFound("Product.NotFound", $"Product with id {id} not found."));
                
            var mappedProduct = mapper.Map<Product, ProductDTO>(product);
            //// you can use this return 
            //return Result<ProductDTO>.Ok(mappedProduct);
            // or you can use this return
            return mappedProduct; // Implicit convert 'implicit operator Result<T>(T value) => Ok(value)'
        }
    }
}
