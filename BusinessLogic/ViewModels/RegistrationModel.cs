using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Enter UserName")]
        [MaxLength(50,ErrorMessage ="Max length of UserName is 50 symbols")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords aren't equal")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Enter FirstName")]
        [MaxLength(100,ErrorMessage ="Too long FirstName")]
        public  string FirstName { get; set; }

        [Required(ErrorMessage ="Enter SecondName")]
        [MaxLength(100,ErrorMessage ="Too long SecondName")]
        public string SecondName { get; set; }

        [Required(ErrorMessage ="Enter your City")]
        [MaxLength(100,ErrorMessage ="Too long city name")]
        public virtual string City { get; set; }

    }
}
