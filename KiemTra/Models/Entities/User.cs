using System.ComponentModel.DataAnnotations;

namespace KiemTra.Models.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [MaxLength(255)]
        public string Avatar { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        public DateTime? Birthday { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        // Navigation property
        public ICollection<Score> Scores { get; set; }
    }
}
