using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;

namespace UtopiaCity.Common.Initializers
{
    public class PositionInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Positions.Any())
            {
                return;
            }
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Positions.Any())
            {
                return;
            }

            var position1 = new Position
            {
                Name = "позиция 1"
            };

            var position2 = new Position
            {
                Name = "позиция 2"
            };

            var position3 = new Position
            {
                Name = "позиция 3"
            };

            context.AddRange(position1, position2, position3);
            context.SaveChanges();
        }
    }
}
