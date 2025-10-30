using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using Domain;
using MediatR;

namespace Application.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Result<IEnumerable<Category>>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<IEnumerable<Category>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Category> categories = await _categoryRepository.GetAllAsync();
        return ResultFactory.From(categories);
    }
}
