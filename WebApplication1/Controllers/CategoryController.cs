using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/category")]
public class CategoryController : ApiController
{
    private readonly ISender _sender;

    public CategoryController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await _sender.Send(new Application.Categories.Queries.GetAllCategories.GetAllCategoriesQuery());
        return result.IsSuccess
            ? Ok(result.Value)
            : Problem(result.Errors);
    }
}
