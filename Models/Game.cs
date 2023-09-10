using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lan_game_hub_api.Models
{
    [Table("games")]
    public class Game
    {
        [Key]
        [Column("game_id")]
        public int game_id { get; set; }

        [Column("game_name")]
        public string game_name { get; set; }

        [Column("game_mode")]
        public string game_mode { get; set; }

        [Column("game_start_time")]
        public string game_start_time { get; set; }
    }
}
