using AutoMapper;
using ECommerce.Application.DTOs.Products;
using ECommerce.Domain.Entities.Products;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Profiles
{
    public class PictureUrlResolver(IOptions<UrlSettings> options) : IValueResolver<Product, ProductDTO, string?>
    {
        private readonly UrlSettings urlSettings = options.Value;
        public string? Resolve(Product source, ProductDTO destination, string? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl)) return null;

            var baseUrl = urlSettings.BaseUrl.TrimEnd('/');
            var path = source.PictureUrl.TrimStart('/');

            return $"{baseUrl}/Files/{path}";
        }
    }

    public class UrlSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
    }
}
