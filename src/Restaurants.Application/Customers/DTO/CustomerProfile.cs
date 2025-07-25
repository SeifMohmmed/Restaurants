using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Customers.DTO;
public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDTO>();
    }
}
