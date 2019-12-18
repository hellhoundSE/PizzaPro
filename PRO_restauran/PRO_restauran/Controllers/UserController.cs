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
        public IActionResult GetUsers()
        {
            return Ok(_context.User.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            User user = _context.User.FirstOrDefault(e => e.IdUser == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            if (_context.User.FirstOrDefault(u => u.IdUser == user.IdUser) == null)
            {
                return NotFound();
            }
            _context.User.Attach(user);
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            User user = _context.User.FirstOrDefault(u => u.IdUser == id);
            if (user == null)
            {
                return NotFound();
            }
            _context.User.Remove(user);
            _context.SaveChanges();
            return Ok(user);
        }

    }
}