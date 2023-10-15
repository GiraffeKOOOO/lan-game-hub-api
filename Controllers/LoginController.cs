using lan_game_hub_api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace lan_game_hub_api.Controllers
{
    [Route("api/Login")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public LoginController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AuthenticateUser(string queriedUsername, string queriedPassword)
        {
            var user = _dbContext.Users.Where(p => p.user_name == queriedUsername).First();

            if (user?.user_password == queriedPassword)
            {
                return user;
            }
            else
            {
                return BadRequest();
            }
           
        }
    }
}
