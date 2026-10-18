using AutoMapper;
using ECommerce.Application.DTOs.Products;
using ECommerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductsBrand, BrandDTO>();
            CreateMap<ProductsType, TypeDTO>();

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name));
        }
    }
}
