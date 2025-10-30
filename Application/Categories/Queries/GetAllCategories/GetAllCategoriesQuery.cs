using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery : IQuery<Result<IEnumerable<Category>>>
{
}
