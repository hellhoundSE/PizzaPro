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
        public IActionResult getDeliverymans()
        {
            List<Deliveryman> list = _context.Deliveryman.ToList();
            if (list == null)
                return NotFound();
            return Ok(list);
        }

        [HttpGet("(id:int)")]
        public IActionResult getDeliverymanById(int id)
        {
            Deliveryman meal = _context.Deliveryman.FirstOrDefault(m => m.IdDeliveryman == id);
            if (meal == null)
                return NotFound();
            return Ok(meal);
        }
    }
}