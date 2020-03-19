using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class Vacancy
    {
        [Key]
        public int VacancyId { get; set; }
        [MaxLength(300)]
        public string ShortDescription { get; set; }
        [Required]
        [MaxLength(2000)]
        public string FullDescription { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
