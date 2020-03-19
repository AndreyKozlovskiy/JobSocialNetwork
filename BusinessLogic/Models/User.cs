using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class User
    {
        public User()
        {
            Vacancies = new List<Vacancy>();
            Resumes = new List<Resume>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(100)]
        public string Mail { get; set; }
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200)]
        public string SecondName { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        public virtual List<Vacancy> Vacancies { get; set; }
        public virtual List<Resume> Resumes { get; set; }
    }
}
