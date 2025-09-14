using Application.Foods.Queries.GetAllFoods;
using Application.Foods.Queries.GetFoodById;
using Application.Foods.Queries.GetFoodsByCategory;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/food")]
public class FoodController : ApiController
{
    private readonly ISender _sender;

    public FoodController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFood()
    {
        var result = await _sender.Send(new GetAllFoodsQuery());
        return result.IsSuccess 
            ? Ok(result.Value) 
            : BadRequest(result.Error);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetFoodById(int id)
    {
        var result = await _sender.Send(new GetFoodByIdQuery(id));
        return result.IsSuccess
            ? Ok(result.Value)
            : NotFound(result.Error);
    }

    [HttpGet("by-category")]
    public async Task<IActionResult> GetFoodByCategory([FromQuery] FoodCategory category)
    {
        var result = await _sender.Send(new GetFoodsByCategoryQuery(category));
        return result.IsSuccess 
            ? Ok(result.Value) 
            : BadRequest(result.Error);
    }
}
