using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lan_game_hub_api.Models
{
    [Table("gameplayers")]
    public class GamePlayer
    {
        [Key]
        [Column("game_id")]
        public int game_id { get; set; }

        [Column("user_id")]
        public int user_id { get; set; }
    }
}
