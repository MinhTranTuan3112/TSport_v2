using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TSport.Api.BusinessLogic.Interfaces;
using TSport.Api.BusinessLogic.Services;
using TSport.Api.DataAccess.Interfaces;

namespace TSport.Api.BusinessLogic
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly Lazy<IShirtService> _shirtService;
        private readonly Lazy<ITokenService> _tokenService;
        private readonly Lazy<IAuthService> _authService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public ServiceFactory(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _shirtService = new Lazy<IShirtService>(() => new ShirtService(unitOfWork));
            _tokenService = new Lazy<ITokenService>(() => new TokenService(configuration));
            _authService = new Lazy<IAuthService>(() => new AuthService(unitOfWork, this));
        }

        public IAuthService GetAuthService()
        {
            return _authService.Value;
        }

        public IShirtService GetShirtService()
        {
            return _shirtService.Value;
        }

        public ITokenService GetTokenService()
        {
            return _tokenService.Value;
        }
    }
}