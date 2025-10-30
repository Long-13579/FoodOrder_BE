using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Models;
using Application.Common.Results;
using MediatR;

namespace Application.Foods.Queries.GetFoodsByCategory;

public class GetFoodsByCategoryQueryHandler : IRequestHandler<GetFoodsByCategoryQuery, Result<IEnumerable<FoodDTO>>>
{
    private readonly IFoodRepository _foodRepository;
    public GetFoodsByCategoryQueryHandler(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
    }
    public async Task<Result<IEnumerable<FoodDTO>>> Handle(GetFoodsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await _foodRepository.GetFoodsByCategoryAsync(request.CategoryId);
        return ResultFactory.From(result);
    }
}
