using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TSport.Api.BusinessLogic.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(int accountId, string role);

        string GenerateRefreshToken();

        ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string expiredAccessToken);
    }
}