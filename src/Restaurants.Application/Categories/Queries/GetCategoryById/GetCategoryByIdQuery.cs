using MediatR;
using Restaurants.Application.Categories.DTO;

namespace Restaurants.Application.Categories.Queries.GetCategoryById;
public class GetCategoryByIdQuery(int categoryId) : IRequest<CategoryDTO>
{
    public int CategoryId { get; } = categoryId;
}
