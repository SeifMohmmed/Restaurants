using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.DTOs;
public class RestaurantsProfile : Profile
{
    public RestaurantsProfile()
    {
        CreateMap<UpdateRestaurantCommand, Restaurant>();

        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(des => des.Address, opt => opt.MapFrom(
                src => new Address()
                {
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Street = src.Street
                }));

        CreateMap<Restaurant, RestaurantDTO>()
            .ForMember(des => des.City, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.City))

            .ForMember(des => des.PostalCode, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))

            .ForMember(des => des.Street, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.Street))

            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));

    }
}
