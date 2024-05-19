using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSport.Api.BusinessLogic.Interfaces
{
    public interface IServiceFactory
    {
        IShirtService GetShirtService();
        ITokenService GetTokenService();
        IAuthService GetAuthService();
    }
}