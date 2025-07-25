using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Categories.DTO;
using Restaurants.Application.Common;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Categories.Queries.GetAllCategories;
public class GetAllCategoriesQueryHandler(ILogger<GetAllCategoriesQueryHandler> logger,
    ICategoryRepository categoryRepository,
    IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, PagedResult<CategoryDTO>>
{
    public async Task<PagedResult<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving All Categories");

        var (categories, totalCount) = await categoryRepository.GetAllMathchingAsync(request.SearchPhrase,
           request.PageSize,
           request.PageNumber,
           request.SortBy,
           request.SortDirection);

        var categoriesDTO = mapper.Map<IEnumerable<CategoryDTO>>(categories);

        var result = new PagedResult<CategoryDTO>(categoriesDTO, totalCount, request.PageSize, request.PageNumber);
        return result;
    }
}
