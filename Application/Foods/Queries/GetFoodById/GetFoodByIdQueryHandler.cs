using Application.Common.Results;
using Application.Common.Errors;
using MediatR;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Models;

namespace Application.Foods.Queries.GetFoodById;

public class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, Result<FoodDTO>>
{
    private readonly IFoodRepository _foodRepository;

    public GetFoodByIdQueryHandler(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
    }

    public async Task<Result<FoodDTO>> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _foodRepository.GetFoodByIdAsync(request.Id);
        return result is null
            ? Errors.Food.NotFound(request.Id)
            : result;
    }
}
