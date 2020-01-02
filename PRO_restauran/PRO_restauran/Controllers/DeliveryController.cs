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
    public class DeliveryController : ControllerBase
    {
        private s17239Context _context;
        public DeliveryController(s17239Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Methond returns delivery with given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Delivery object with given ID
        /// </returns>
        [HttpGet("{id:int}")]
        public IActionResult GetDeliveryById(int id)
        {
            Delivery delivery = _context.Delivery.FirstOrDefault(d => d.IdDelivery==id);
            if (delivery == null)
                return NotFound();
            return Ok(delivery);
        }
        /// <summary>
        /// Methonds returns deliveries for given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>
        /// Returns list of user's delivery
        /// </returns>
        [HttpGet("user/{userId:int}")]
        public IActionResult GetDeliveryByUserId(int userId)
        {
            List<Delivery> list = _context.Delivery.Where(delivery => delivery.UserIdUser == userId).OrderBy(d => d.DeliveryTime).ToList();
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        /// <summary>
        /// Post method to add new delivery
        /// </summary>
        /// <param name="delivery"></param>
        /// <returns>
        /// Returns new added delivery
        /// </returns>
        [HttpPost]
        public IActionResult AddDelivery(Delivery delivery)
        {
            _context.Delivery.Add(delivery);
            _context.SaveChanges();
            return Ok(delivery);
        }

        /// <summary>
        /// Put method to update delivery
        /// </summary>
        /// <param name="delivery"></param>
        /// <returns>
        /// Return new updated delivery
        /// </returns>
        [HttpPut]
        public IActionResult UpdateDelivery(Delivery delivery)
        {
            if(_context.Delivery.FirstOrDefault(d => d.IdDelivery == delivery.IdDelivery) == null)
            {
                return NotFound();
            }
            _context.Delivery.Attach(delivery);
            _context.Entry(delivery).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok(delivery);
        }

        /// <summary>
        /// Delete method to delete given delivery
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns just deleted delivery
        /// </returns>
        [HttpDelete("{id:int}")]
        public IActionResult DeleteDelivery(int id)
        {
            Delivery delivery = _context.Delivery.FirstOrDefault(d => d.IdDelivery == id);
            if (delivery == null)
            {
                return NotFound();
            }
            _context.Delivery.Remove(delivery);
            _context.SaveChanges();
            return Ok(delivery);
        }
    }
}