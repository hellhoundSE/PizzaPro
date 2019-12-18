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
    public class DeliverymanController : ControllerBase
    {

        private s17239Context _context;
        public DeliverymanController(s17239Context context)
        {
            _context = context;
        }

        [HttpGet("/all")]
        public IActionResult GetDeliverymans()
        {
            List<Deliveryman> list = _context.Deliveryman.OrderBy(d => d.Name).ToList();
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpGet("(id:int)")]
        public IActionResult GetDeliverymanById(int id)
        {
            Deliveryman meal = _context.Deliveryman.FirstOrDefault(m => m.IdDeliveryman == id);
            if (meal == null)
                return NotFound();
            return Ok(meal);
        }

        [HttpPost]
        public IActionResult AddDeliveryman(Deliveryman deliveryman)
        {
            _context.Deliveryman.Add(deliveryman);
            _context.SaveChanges();
            return Ok(deliveryman);
        }

        [HttpPut]
        public IActionResult UpdateDeliveryman(Deliveryman deliveryman)
        {
            if (_context.Deliveryman.FirstOrDefault(d => d.IdDeliveryman== deliveryman.IdDeliveryman) == null)
            {
                return NotFound();
            }
            _context.Deliveryman.Attach(deliveryman);
            _context.Entry(deliveryman).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok(deliveryman);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDeliveryman(int id)
        {
            Deliveryman deliveryman = _context.Deliveryman.FirstOrDefault(d => d.IdDeliveryman == id);
            if (deliveryman == null)
            {
                return NotFound();
            }
            _context.Deliveryman.Remove(deliveryman);
            _context.SaveChanges();
            return Ok(deliveryman);
        }
    }
}