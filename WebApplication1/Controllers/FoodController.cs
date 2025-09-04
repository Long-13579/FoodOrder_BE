using Application.Services.Foods;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/food")]
public class FoodController : ApiController
{
    private readonly IFoodService _foodService;

    public FoodController(IFoodService foodService)
    {
        _foodService = foodService ?? throw new ArgumentNullException(nameof(foodService));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFood()
    {
        IEnumerable<Food> foods = await _foodService.GetAllFoodsAsync();
        return Ok(foods);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetFoodById(int id)
    {
        var result = await _foodService.GetFoodByIdAsync(id);
        
        if (result == null)
        {
            return NotFound($"Food with ID {id} not found.");
        }

        return Ok(result);
    }

    [HttpGet("by-category")]
    public async Task<IActionResult> GetFoodByCategory([FromQuery] FoodCategory category)
    {
        var foods = await _foodService.GetFoodsByCategoryAsync(category);
        return Ok(foods);
    }
}
