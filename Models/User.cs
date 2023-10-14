using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lan_game_hub_api.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int user_id { get; set; }

        [Column("user_name")]
        public string user_name { get; set; }
        
        [Column("user_password")]
        public string user_password{ get; set; }

        [Column("user_role")]
        public string user_role { get; set; }
    }
}
