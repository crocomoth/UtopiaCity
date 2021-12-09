using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Common.Interfaces
{
    public interface ICustomSoftDelete
    {
        bool IsActive { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
