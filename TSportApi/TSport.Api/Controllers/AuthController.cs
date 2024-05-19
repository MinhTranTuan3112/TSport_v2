using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSport.Api.BusinessLogic.Interfaces;
using TSport.Api.DataAccess.DTOs.Accounts;
using TSport.Api.DataAccess.DTOs.Auth;

namespace TSport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public AuthController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }


        [HttpPost("login")]
        public async Task<ActionResult<GetAuthTokensDto>> Login([FromBody] LoginDto loginDto)
        {
            return await _serviceFactory.GetAuthService().Login(loginDto);
        }

        [HttpGet("who-am-i")]
        [Authorize]
        public async Task<ActionResult<GetAccountDto>> WhoAmI()
        {
            return await _serviceFactory.GetAuthService().GetAuthAccount(HttpContext.User);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
        {
            await _serviceFactory.GetAuthService().Register(registerDto);
            return Ok();
        }
    }
}