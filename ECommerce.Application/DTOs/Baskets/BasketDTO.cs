using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.DTOs.Baskets
{
    public class BasketDTO
    {
        public string Id { get; set; } = default!;
        public ICollection<BasketItemDTO> Items { get; set; } = [];
    }
}
