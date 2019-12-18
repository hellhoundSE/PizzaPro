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
        public IActionResult getDeliveryById(int id)
        {
            Delivery delivery = _context.Delivery.FirstOrDefault(d => d.IdDelivery==id);
            if (delivery == null)
                return NotFound();
            return Ok(delivery);
        }

        [HttpGet("user/{userId:int}")]
        public IActionResult getDeliveryByUserId(int userId)
        {
            List<Delivery> list = _context.Delivery.Where(delivery => delivery.UserIdUser == userId).ToList();
            if (list == null)
                return NotFound();
            return Ok(list);
        }

    }
}