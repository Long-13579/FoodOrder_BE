using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using Domain;
using MediatR;

namespace Application.Foods.Queries.GetFoodsByCategory;

public class GetFoodsByCategoryQueryHandler : IRequestHandler<GetFoodsByCategoryQuery, Result<IEnumerable<Food>>>
{
    private readonly IFoodRepository _foodRepository;
    public GetFoodsByCategoryQueryHandler(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
    }
    public async Task<Result<IEnumerable<Food>>> Handle(GetFoodsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await _foodRepository.GetFoodsByCategoryAsync(request.Category);
        return ResultFactory.From(result);
    }
}
