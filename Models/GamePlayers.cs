using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lan_game_hub_api.Models
{
    [Table("{name:game_name}_players")]
    public class GamePlayers
    {
        [Key]
        [Column("user_id")]
        public int user_id { get; set; }

        [ForeignKey("game_id")]
        [Column("game_id")]
        public int game_id { get; set; }


        [Column("player_team")]
        public string? player_team { get; set; }
    }
}
