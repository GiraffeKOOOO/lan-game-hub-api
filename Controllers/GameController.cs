using lan_game_hub_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lan_game_hub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly UserDbContext _dbContext;

        public GameController(UserDbContext userDbContext)
        {
            _dbContext = userDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetGames()
        {
            return _dbContext.Games;
        }

        [HttpGet("{gameId:int}")]
        public async Task<ActionResult<Game>> GetGameById(int gameId)
        {
            var game = await _dbContext.Games.FindAsync(gameId);
            return game;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Game game)
        {
            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Game game)
        {
            _dbContext.Games.Update(game);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{gameId:int}")]
        public async Task<ActionResult> Delete(int gameId)
        {
            var game = await _dbContext.Games.FindAsync(gameId);
            _dbContext.Games.Remove(game);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
