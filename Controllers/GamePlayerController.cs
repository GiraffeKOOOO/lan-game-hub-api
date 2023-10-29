using lan_game_hub_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lan_game_hub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamePlayerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GamePlayerController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GamePlayer>> GetAllGamePlayers()
        {
            return _dbContext.GamePlayer;
        }

        [HttpGet("{gameId:int}")]
        public async Task<List<GamePlayer>> GetGamePlayers(int gameId)
        {
            var gameplayer = await _dbContext.GamePlayer.Where(gameplayer => gameplayer.game_id == gameId).ToListAsync();
            return gameplayer;
        }

        [HttpPost]
        public async Task<ActionResult> AddGamePlayers(GamePlayer gamePlayer)
        {
            await _dbContext.GamePlayer.AddAsync(gamePlayer);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class GetGamePlayerCountController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GetGamePlayerCountController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        [HttpGet("{gameId:int}")]
        public async Task<int> GetGamePlayersCount(int gameId)
        {
            var gameplayer = await _dbContext.GamePlayer.Where(gameplayer => gameplayer.game_id == gameId).ToListAsync();
            return gameplayer.Count;
        }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class GetGamePlayerStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GetGamePlayerStatusController(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<bool> GetGamePlayersStatus(int gameId, int userId)
        {

            var gameplayer = await _dbContext.GamePlayer.Where(gameplayer => gameplayer.game_id == gameId).Where(gameplayer => gameplayer.user_id == userId).FirstOrDefaultAsync();
            if (gameplayer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
    