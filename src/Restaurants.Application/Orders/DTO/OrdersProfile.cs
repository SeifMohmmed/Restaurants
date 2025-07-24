using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Orders.DTO;
public class OrdersProfile : Profile
{
    public OrdersProfile()
    {
        CreateMap<Order, OrderDTO>();

        CreateMap<OrderItem, OrderItemDTO>()
            .ForMember(d => d.DishName,
                opt => opt.MapFrom(src => src.Dish.Name));
    }
}
