using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace UtopiaCity.Common
{
    public static class GetInformationAboutAuthenticatedUser
    {
        public static string GetAuthenticatedUsersId(IHttpContextAccessor httpContextAccessor)
            => httpContextAccessor
                .HttpContext
                .User
                .FindFirst(ClaimTypes.NameIdentifier)
                .Value;
    }
}
