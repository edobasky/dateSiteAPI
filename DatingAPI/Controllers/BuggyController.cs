using DatingAPI.Data;
using DatingAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly DataContext _dataConext;

        public BuggyController(DataContext dataConext)
        {
            _dataConext = dataConext;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret() {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<Appuser> GetNotFound()
        {
            var thing = _dataConext.Users.Find(-1);

            if (thing == null) return NotFound();

            return thing;
            
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError() 
        {
            var thing = _dataConext.Users.Find(-1);

            var thingToReturn = thing.ToString();

            return thingToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetError() 
        {
            return BadRequest("This was not a good request");
        }

    }

}
