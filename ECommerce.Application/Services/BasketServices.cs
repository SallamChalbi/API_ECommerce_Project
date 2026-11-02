using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.Contracts;
using ECommerce.Application.DTOs.Baskets;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities.Baskets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
    public class BasketServices : IBasketServices
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;

        public BasketServices(IBasketRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<BasketDTO>> CreateOrUpdateBasketAsync(BasketDTO basket, CancellationToken ct = default)
        {
            var customerBasket = _mapper.Map<CustomerBasket>(basket);
            var result = await _repository.CreateOrUpdateBasketAsync(customerBasket, TimeSpan.FromDays(1), ct);

            return result is not null ? Result<BasketDTO>.Ok(_mapper.Map<BasketDTO>(result)) 
                : Result<BasketDTO>.Fail(Error.Failure("CreateOrUpdateBasket.Failure", "Canot Set this Basket"));
        }

        public async Task<Result<bool>> DeleteBasketAsync(string id, CancellationToken ct = default)
        {
            var result = await _repository.DeleteBasketAsync(id, ct);

            return result ? Result<bool>.Ok(true) 
                : Result<bool>.Fail(Error.Failure("DeleteBasket.Failure", "Canot Delete this Basket"));
        }

        public async Task<Result<BasketDTO>> GetBasketAsync(string id, CancellationToken ct = default)
        {
            var basket = await _repository.GetBasketAsync(id, ct);
            
            return basket is not null ? Result<BasketDTO>.Ok(_mapper.Map<BasketDTO>(basket))
                : Result<BasketDTO>.Fail(Error.NotFound("GetBasket.NotFound", "Basket Not Found"));
        }
    }
}
