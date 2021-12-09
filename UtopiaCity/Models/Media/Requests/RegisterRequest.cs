using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Media.Account
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "field should be filled")]
        public string FName { get; set; }

        [Required(ErrorMessage = "field should be filled")]
        public string LName { get; set; }

        [Required(ErrorMessage = "email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "passwords should be equal")]
        public string ConfirmPassword { get; set; }
    }
}
