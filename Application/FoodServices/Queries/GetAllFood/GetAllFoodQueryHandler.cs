using Application.Common.Interfaces;
using Domain;
using ErrorOr;
using MediatR;

namespace Application.FoodServices.Queries.GetAllFood;

public class GetAllFoodQueryHandler : IRequestHandler<GetAllFoodQuery, IEnumerable<Food>>
{
    private readonly IFoodRepository _foodRepository;

    public GetAllFoodQueryHandler(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }

    public async Task<IEnumerable<Food>> Handle(GetAllFoodQuery request, CancellationToken cancellationToken)
    {
        return await _foodRepository.GetAllFoodsAsync();
    }
}
