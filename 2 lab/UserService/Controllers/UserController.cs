using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Text;

namespace UserService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserServiceContext _context;

        public UsersController(UserServiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUser()
        {
            return Ok(await _context.User.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User user)
        {
            var dbUser = await _context.User.FindAsync(user.ID);
            if (dbUser == null)
                return BadRequest("User not found.");

            dbUser.Name = user.Name;
            dbUser.Mail = user.Mail;
            dbUser.Purchase = user.Purchase;

            await _context.SaveChangesAsync();

            return Ok(await _context.User.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.User.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int ID)
        {
            var dbUser = await _context.User.FindAsync(ID);
            if (dbUser == null)
                return BadRequest("User not found.");

            _context.User.Remove(dbUser);
            await _context.SaveChangesAsync();

            return Ok(await _context.User.ToListAsync());
        }
    }
}
