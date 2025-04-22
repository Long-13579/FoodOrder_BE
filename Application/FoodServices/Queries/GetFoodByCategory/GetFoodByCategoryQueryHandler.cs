using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.FoodServices.Queries.GetFoodByCategory;

public class GetFoodByCategoryQueryHandler : IRequestHandler<GetFoodByCategoryQuery, IEnumerable<Food>>
{
    private readonly IFoodRepository _foodRepository;
    public GetFoodByCategoryQueryHandler(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }
    public async Task<IEnumerable<Food>> Handle(GetFoodByCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _foodRepository.GetFoodsByCategoryAsync(request.Category);
    }
}