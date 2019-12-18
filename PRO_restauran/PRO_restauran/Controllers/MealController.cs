using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRO_restauran.Models;

namespace PRO_restauran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private s17239Context _context;
        public MealController(s17239Context context)
        {
            _context = context;
        }

        [HttpGet("/all")]
        public IActionResult getMeals()
        {
            List<Meal> list = _context.Meal.ToList();
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpGet("(name:string)")]
        public IActionResult getMealByName(string name)
        {
            List<Meal> list = _context.Meal.Where(meal => meal.Name.StartsWith(name)).ToList();
            if(list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpGet("(id:int)")]
        public IActionResult getMealById(int id)
        {
            Meal meal = _context.Meal.FirstOrDefault(m => m.IdMeal == id);
            if (meal == null)
                return NotFound();
            return Ok(meal);
        }

        [HttpGet("/description(description:string)")]
        public IActionResult getMealByDescription(string description)
        {
            List<Meal> list = _context.Meal.Where(meal => meal.Description.Contains(description)).ToList();
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpGet("/price(price:double)")]
        public IActionResult getMealByPrice(double price)
        {
            List<Meal> list = _context.Meal.Where(meal => meal.Price <= price).ToList();
            if (list == null)
                return NotFound();
            return Ok(list);
        }
    }
}