using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.DTOs;
public class RestaurantsProfile : Profile
{
    public RestaurantsProfile()
    {
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
