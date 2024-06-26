﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetOneById;

internal class GetOneByIdQueryHandler(IRestaurantsRepository restaurantsRepository,
    ILogger<GetOneByIdQueryHandler> logger,
    IMapper mapper) : IRequestHandler<GetOneByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetOneByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting one restaurant {RestaurantId}", request.Id);
        var restaurant = await restaurantsRepository.GetOneByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
        return restaurantDto;
    }
}
