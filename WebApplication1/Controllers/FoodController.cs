using Application.FoodServices.Queries.GetAllFood;
using Application.FoodServices.Queries.GetFoodByCategory;
using Application.FoodServices.Queries.GetFoodById;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/food")]
public class FoodController : ApiController
{
    private readonly ISender _mediator;

    public FoodController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFood()
    {
        IEnumerable<Food> foods = await _mediator.Send(new GetAllFoodQuery());
        return Ok(foods);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetFoodById(int id)
    {
        var result = await _mediator.Send(new GetFoodByIdQuery(id));
        
        return result.Match(
            food => Ok(food), 
            error => Problem(error));
    }

    [HttpGet("by-category")]
    public async Task<IActionResult> GetFoodByCategory([FromQuery] FoodCategory category)
    {
        var foods = await _mediator.Send(new GetFoodByCategoryQuery(category));
        return Ok(foods);
    }
}
