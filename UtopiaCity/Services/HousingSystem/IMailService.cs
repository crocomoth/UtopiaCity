using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Services.HousingSystem
{
    public interface IMailService
    {
        void SendMessage(string to, string subject, string body);
    }
}
