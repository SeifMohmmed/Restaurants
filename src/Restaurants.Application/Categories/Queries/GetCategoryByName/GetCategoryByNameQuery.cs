using MediatR;
using Restaurants.Application.Categories.DTO;

namespace Restaurants.Application.Categories.Queries.GetCategoryByName;
public class GetCategoryByNameQuery(string name) : IRequest<CategoryDTO>
{
    public string Name { get; } = name;
}
