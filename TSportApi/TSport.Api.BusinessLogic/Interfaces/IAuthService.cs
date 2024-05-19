using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TSport.Api.DataAccess.DTOs.Accounts;
using TSport.Api.DataAccess.DTOs.Auth;

namespace TSport.Api.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        Task<GetAuthTokensDto> Login(LoginDto loginDto);

        Task<GetAccountDto> GetAuthAccount(ClaimsPrincipal claims);

        Task Register(RegisterDto registerDto);
    }
}