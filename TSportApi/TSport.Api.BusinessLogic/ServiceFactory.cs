using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSport.Api.BusinessLogic.Interfaces;
using TSport.Api.BusinessLogic.Services;
using TSport.Api.DataAccess.Interfaces;

namespace TSport.Api.BusinessLogic
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly Lazy<IShirtService> _shirtService;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _shirtService = new Lazy<IShirtService>(() => new ShirtService(unitOfWork));
        }

        public IShirtService GetShirtService()
        {
            return _shirtService.Value;
        }
    }
}