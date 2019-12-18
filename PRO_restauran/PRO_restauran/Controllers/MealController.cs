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

        /// <summary>
        /// Method returns all available meals
        /// </summary>
        /// <returns>
        /// return list of all meals
        /// </returns>
        [HttpGet]
        public IActionResult GetMeals()
        {
            List<Meal> list = _context.Meal.OrderBy(m => m.TypeIdType).ToList();
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpGet("(name:string)")]
        public IActionResult GetMealByName(string name)
        {
            List<Meal> list = _context.Meal.Where(meal => meal.Name.StartsWith(name)).ToList();
            if(list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpGet("(id:int)")]
        public IActionResult GetMealById(int id)
        {
            Meal meal = _context.Meal.FirstOrDefault(m => m.IdMeal == id);
            if (meal == null)
                return NotFound();
            return Ok(meal);
        }

        [HttpGet("/description(description:string)")]
        public IActionResult GetMealByDescription(string description)
        {
            List<Meal> list = _context.Meal.Where(meal => meal.Description.Contains(description)).ToList();
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpGet("/price(price:double)")]
        public IActionResult GetMealByPrice(double price)
        {
            List<Meal> list = _context.Meal.Where(meal => meal.Price <= price).ToList();
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddMeal(Meal meal)
        {
            _context.Meal.Add(meal);
            _context.SaveChanges();
            return Ok(meal);
        }

        [HttpPut]
        public IActionResult UpdateMeal(Meal meal)
        {
            if (_context.Meal.FirstOrDefault(m => m.IdMeal == m.IdMeal) == null)
            {
                return NotFound();
            }
            _context.Meal.Attach(meal);
            _context.Entry(meal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok(meal);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteMeal(int id)
        {
            Meal meal = _context.Meal.FirstOrDefault(m => m.IdMeal == id);
            if (meal == null)
            {
                return NotFound();
            }
            _context.Meal.Remove(meal);
            _context.SaveChanges();
            return Ok(meal);
        }
    }
}