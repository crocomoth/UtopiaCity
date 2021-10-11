using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Media.Responses
{
    public class AuthenticateResponse
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
