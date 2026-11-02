using ECommerce.Application.Common;
using ECommerce.Application.DTOs.Baskets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Contracts
{
    public interface IBasketServices
    {
        Task<Result<BasketDTO>> GetBasketAsync(string id, CancellationToken ct = default);
        Task<Result<BasketDTO>> CreateOrUpdateBasketAsync(BasketDTO basket, CancellationToken ct = default);
        Task<Result<bool>> DeleteBasketAsync(string id, CancellationToken ct = default);
    }
}
