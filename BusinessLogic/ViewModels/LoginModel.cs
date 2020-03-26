using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter UserName")]
        [MaxLength(50, ErrorMessage = "Max length of UserName is 50 symbols")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
