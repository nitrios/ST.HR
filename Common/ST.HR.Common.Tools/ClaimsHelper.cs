using System.Security.Claims;

namespace ST.HR.Common.Tools
{
    public static class ClaimsHelper
    {
        public static string GetClaim(ClaimsPrincipal claims, string type)
        {
            return !claims.HasClaim(c => c.Type == type) ? "" : claims.FindFirst(c => c.Type == type).Value;
        }
    }
}
