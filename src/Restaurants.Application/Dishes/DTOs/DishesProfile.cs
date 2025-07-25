using AutoMapper;
using Restaurants.Application.Dishes.Command.CreateDish;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.DTOs;
public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dish, DishDTO>()
                .ForMember(d => d.RestaurantName,
                    opt => opt.MapFrom(src => src.Restaurant.Name))
                  .ForMember(d => d.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<CreateDishCommand, Dish>();

    }
}
