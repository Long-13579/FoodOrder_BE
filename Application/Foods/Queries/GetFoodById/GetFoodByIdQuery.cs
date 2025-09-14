using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Foods.Queries.GetFoodById;

public class GetFoodByIdQuery : IQuery<Result<Food>>
{
    public int Id { get; set; }
    public GetFoodByIdQuery(int id)
    {
        Id = id;
    }
}
