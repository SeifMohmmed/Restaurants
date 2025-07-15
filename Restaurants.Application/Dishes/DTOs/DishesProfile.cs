using AutoMapper;
using Restaurants.Application.Dishes.DTOs.Command.CreateDish;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.DTOs;
public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dish, DishDTO>();

        CreateMap<CreateDishCommand, Dish>();

    }
}
