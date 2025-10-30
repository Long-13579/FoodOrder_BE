using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Models;
using Application.Common.Results;
using MediatR;

namespace Application.Foods.Queries.GetAllFoods;

public class GetAllFoodsQueryHandler : IRequestHandler<GetAllFoodsQuery, Result<IEnumerable<FoodDTO>>>
{
    private readonly IFoodRepository _foodRepository;

    public GetAllFoodsQueryHandler(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
    }

    public async Task<Result<IEnumerable<FoodDTO>>> Handle(GetAllFoodsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<FoodDTO> foods = await _foodRepository.GetAllFoodsAsync();
        return ResultFactory.From(foods);
    }
}
