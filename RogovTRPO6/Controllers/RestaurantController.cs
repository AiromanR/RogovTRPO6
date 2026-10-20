using Microsoft.AspNetCore.Mvc;
using RogovTRPO6.Models;
using RogovTRPO6.Services;

namespace RogovTRPO6.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RestaurantController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll ([FromQuery] string? cuisine, [FromQuery] decimal? minRating)
        {
            List<Restaurant> restaurants = RestaurantService.GetAllRest(cuisine, minRating);
            return Ok(restaurants);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var restaurant = RestaurantService.Get(id);
            if (restaurant != null) return Ok(restaurant);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Restaurant restaurant)
        {
            bool res  = RestaurantService.AddRest(restaurant);
            if(res) return Created($"/api/v1/restaurant/{restaurant.Id}", restaurant);
            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Restaurant restaurant)
        {
            bool res = RestaurantService.PutRest(id, restaurant);
            if (res)
            {
                var updated = RestaurantService.Get(id);
                return Ok(updated);
            }
            if (RestaurantService.Get(id) == null) return NotFound();
            return BadRequest();
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch (int id, RestaurantDTO restaurantDTO)
        {
            bool res = RestaurantService.PatchRest(id, restaurantDTO);
            if (res)
            {
                var updated = RestaurantService.Get(id);
                return Ok(updated);                      
            }
            if (RestaurantService.Get(id) == null) return NotFound();
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            bool res = RestaurantService.DeleteRest(id);
            if (res) return Ok();
            return NotFound( );
        }
    }
}