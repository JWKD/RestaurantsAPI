using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Commands.DeleteDish;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDishes;

public class DeleteDishesForRestaurantCommandHandler(ILogger<DeleteDishesForRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IDishesRepository dishesRepository) : IRequestHandler<DeleteDishesForRestaurantCommand>
{
    public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Removing all dishes from restaurant: {RestaurantId}", request.Id);

        var restaurant = await restaurantsRepository.GetOneByIdAsync(request.Id);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        await dishesRepository.Delete(restaurant.Dishes);
    }
}