using Application.Common.Errors;
using Application.Common.Interfaces;
using Domain;
using ErrorOr;
using MediatR;

namespace Application.FoodServices.Queries.GetFoodById;

public class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, ErrorOr<Food>>
{
    private readonly IFoodRepository _foodRepository;
    public GetFoodByIdQueryHandler(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }
    public async Task<ErrorOr<Food>> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
    {
        Food result = await _foodRepository.GetFoodByIdAsync(request.Id);

        if (result is null)
        {
            return Errors.Food.NotFound(request.Id);
        }

        return result;
    }
}