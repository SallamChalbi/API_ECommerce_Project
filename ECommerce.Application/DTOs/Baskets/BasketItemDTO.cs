using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Application.DTOs.Baskets
{
    public  class BasketItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string PictureUrl { get; set; } = default!;

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.00")]
        public decimal Price { get; set; }

        [Range(1, 99)]
        public int Quantity { get; set; }
    }
}
