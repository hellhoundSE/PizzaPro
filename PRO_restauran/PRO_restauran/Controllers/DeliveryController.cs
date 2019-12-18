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

        [HttpGet("{id:int}")]
        public IActionResult GetDeliveryById(int id)
        {
            Delivery delivery = _context.Delivery.FirstOrDefault(d => d.IdDelivery==id);
            if (delivery == null)
                return NotFound();
            return Ok(delivery);
        }

        [HttpGet("user/{userId:int}")]
        public IActionResult GetDeliveryByUserId(int userId)
        {
            List<Delivery> list = _context.Delivery.Where(delivery => delivery.UserIdUser == userId).OrderBy(d => d.DeliveryTime).ToList();
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddDelivery(Delivery delivery)
        {
            _context.Delivery.Add(delivery);
            _context.SaveChanges();
            return Ok(delivery);
        }

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