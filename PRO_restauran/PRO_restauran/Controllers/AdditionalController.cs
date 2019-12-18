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
    public class AdditionalController : ControllerBase
    {
        private s17239Context _context;
        public AdditionalController(s17239Context context)
        {
            _context = context;
        }

        [HttpGet("type/{typeId:int}")]
        public IActionResult GetAdditionalById(int typeId)
        {
            List<Additional> list = _context.Additional.Where(additional => additional.TypeIdType == typeId).ToList();
            if (list == null)
                return NotFound();
            return Ok(list);
        }




    }
}