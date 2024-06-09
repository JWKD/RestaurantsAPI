using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDish;

public class DeleteDishesForRestaurantCommand(int id) : IRequest
{
    public int Id { get; } = id;
}
