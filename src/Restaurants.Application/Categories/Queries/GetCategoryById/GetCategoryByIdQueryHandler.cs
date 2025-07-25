using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Categories.DTO;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Categories.Queries.GetCategoryById;
public class GetCategoryByIdQueryHandler(ILogger<GetCategoryByIdQuery> logger,
    ICategoryRepository categoryRepository,
    IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, CategoryDTO>
{
    public async Task<CategoryDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation(" Getting Category with id : {CategoryID}", request.CategoryId);

        var category = await categoryRepository.GetByIdAsync(request.CategoryId)
            ?? throw new NotFoundException(nameof(Category), request.CategoryId.ToString());

        var result = mapper.Map<CategoryDTO>(category);

        return result;
    }
}
