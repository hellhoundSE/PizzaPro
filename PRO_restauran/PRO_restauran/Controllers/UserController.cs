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
    public class UserController : ControllerBase
    {
        private s17239Context _context;
        public UserController(s17239Context context)
        {
            _context = context;
        }

        [HttpGet("/all")]
        public IActionResult getUsers()
        {
            return Ok(_context.User.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult getUser(int id)
        {
            User user = _context.User.FirstOrDefault(e => e.IdUser == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }


    }
}