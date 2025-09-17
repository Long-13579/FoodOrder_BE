using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using Domain;
using MediatR;

namespace Application.Foods.Queries.GetAllFoods;

public class GetAllFoodsQueryHandler : IRequestHandler<GetAllFoodsQuery, Result<IEnumerable<Food>>>
{
    private readonly IFoodRepository _foodRepository;

    public GetAllFoodsQueryHandler(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
    }

    public async Task<Result<IEnumerable<Food>>> Handle(GetAllFoodsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Food> foods = await _foodRepository.GetAllFoodsAsync();
        return ResultFactory.From(foods);
    }
}
