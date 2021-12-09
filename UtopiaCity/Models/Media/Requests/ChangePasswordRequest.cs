using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Media.Requests
{
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage = "incorrect email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "incorrect password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
