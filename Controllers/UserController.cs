using lan_game_hub_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lan_game_hub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _dbContext;
        public UserController(UserDbContext userDbContext) 
        {
            _dbContext = userDbContext; 
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _dbContext.Users;
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            return user;
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{userId:int}")]
        public async Task<ActionResult> Delete(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}   