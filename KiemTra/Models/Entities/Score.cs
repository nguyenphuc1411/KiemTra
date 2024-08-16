using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KiemTra.Models.Entities
{
    public class Score
    {
        [Key]
        public int ScoreID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public int Value { get; set; }

        public DateTime Timestamp { get; set; }
        public User User { get; set; }
    }
}
