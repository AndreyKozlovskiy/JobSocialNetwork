using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        [Required]
        [MaxLength(50)]
        public string SkillName { get; set; }
        [Required]
        public Resume Resume { get; set; }
        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
    }
}
