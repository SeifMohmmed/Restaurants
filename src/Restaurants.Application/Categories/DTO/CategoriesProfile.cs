using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Categories.DTO;
public class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<Category, CategoryDTO>();
    }
}
