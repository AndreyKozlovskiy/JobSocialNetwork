using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class Resume
    {
        public Resume()
        {
            Skills = new List<Skill>();
        }

        [Key]
        public int ResumeId { get; set; }
        [MaxLength(300)]
        public string ShortDescription { get; set; }
        [Required]
        [MaxLength(2000)]
        public string FullDescription { get; set; }
        [Required]
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual List<Skill> Skills { get; set; }
    }
}
