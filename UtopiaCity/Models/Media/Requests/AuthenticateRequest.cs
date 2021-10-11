using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Media.Account
{
    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
