using MediatR;

namespace Restaurants.Application.Categories.Command.DeleteCategory;
public class DeleteCategoryCommand(int id) : IRequest
{
    public int Id { get; } = id;
}
