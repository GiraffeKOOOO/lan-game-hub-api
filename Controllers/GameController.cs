using lan_game_hub_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace lan_game_hub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GameController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
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
            // will need to create the players table here
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
