using System.Collections.Generic;

namespace UtopiaCity.Models.CityAdministration
{
    public class AccountsListViewModel
    {
        public IEnumerable<ResidentAccount> Accounts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
