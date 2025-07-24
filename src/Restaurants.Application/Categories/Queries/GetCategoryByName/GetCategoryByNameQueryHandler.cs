using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Categories.DTO;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Categories.Queries.GetCategoryByName;
public class GetCategoryByNameQueryHandler(ILogger<GetCategoryByNameQueryHandler> logger,
    ICategoryRepository categoryRepository,
    IMapper mapper) : IRequestHandler<GetCategoryByNameQuery, CategoryDTO>
{
    public async Task<CategoryDTO> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting Category {CategoryName}", request.Name);

        var category = await categoryRepository.GetByNameAsync(request.Name)
          ?? throw new NotFoundException(nameof(Category), request.Name);

        var categoryDTO = mapper.Map<CategoryDTO>(category);

        return categoryDTO;
    }
}
