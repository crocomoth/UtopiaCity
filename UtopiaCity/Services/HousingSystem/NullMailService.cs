using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Services.HousingSystem
{
    public class NullMailService : IMailService
    {
        private readonly ILogger _logger;
        public NullMailService(ILogger<NullMailService> logger)
        {
            _logger = logger;
        }
        public void SendMessage(string sender, string subject, string receiver)
        {
            // Log the message
            _logger.LogInformation($"{sender} ask for permition to add {subject} from {receiver}");
        }
    }
}
