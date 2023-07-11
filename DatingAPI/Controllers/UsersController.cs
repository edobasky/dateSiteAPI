using DatingAPI.Data;
using DatingAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appuser>>> GetUsers()
        {
            var response = await _context.Users.ToListAsync();
            return response;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Appuser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
