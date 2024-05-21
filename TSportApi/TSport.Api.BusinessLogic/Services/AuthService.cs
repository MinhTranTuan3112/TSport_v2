using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using TSport.Api.BusinessLogic.Interfaces;
using TSport.Api.DataAccess.DTOs.Accounts;
using TSport.Api.DataAccess.DTOs.Auth;
using TSport.Api.DataAccess.Enums;
using TSport.Api.DataAccess.Interfaces;
using TSport.Api.DataAccess.Models;
using TSport.Api.Shared.Exceptions;

namespace TSport.Api.BusinessLogic.Services
{
    public class AuthService : IAuthService

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceFactory _serviceFactory;

        public AuthService(IUnitOfWork unitOfWork, IServiceFactory serviceFactory)
        {
            _unitOfWork = unitOfWork;
            _serviceFactory = serviceFactory;
        }

        public async Task<GetAccountDto> GetAuthAccount(ClaimsPrincipal claims)
        {
            var accountId = claims.FindFirst(c => c.Type == "aid")?.Value;

            if (accountId is null)
            {
                throw new UnauthorizedException("Unauthorized ");                
            }

            var account = await _unitOfWork.GetAccountRepository().FindOneAsync(a => a.Id == Convert.ToInt32(accountId));

            if (account is null)
            {
                throw new UnauthorizedException("Account not found");
            }

            return account.Adapt<GetAccountDto>();
        }

        public async Task<GetAuthTokensDto> Login(LoginDto loginDto)
        {
            var account = await _unitOfWork.GetAccountRepository().FindOneAsync(a => a.Email == loginDto.Email
            && a.Password == HashPassword(loginDto.Password));

            if (account is null)
            {
                throw new UnauthorizedException("Wrong email or password");
            }

            string accessToken = _serviceFactory.GetTokenService().GenerateAccessToken(account.Id, account.Role);
            string refreshToken = _serviceFactory.GetTokenService().GenerateRefreshToken();

            return new GetAuthTokensDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

        }

        public async Task Register(RegisterDto registerDto)
        {
            var accountWithEmail = await _unitOfWork.GetAccountRepository().FindOneAsync(a => a.Email == registerDto.Email);
            if (accountWithEmail is not null)
            {
                throw new BadRequestException($"Account with email {registerDto.Email} is already exists");
            }

            var account = registerDto.Adapt<Account>();
            account.Status = AccountStatus.Active.ToString();
            account.Password = HashPassword(registerDto.Password);

            await _unitOfWork.GetAccountRepository().AddAsync(account);
            await _unitOfWork.SaveChangesAsync();

        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            // Convert the password string to bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Compute the hash
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            // Convert the hash to a hexadecimal string
            string hashedPassword = string.Concat(hashBytes.Select(b => $"{b:x2}"));

            return hashedPassword;
        }
    }
}