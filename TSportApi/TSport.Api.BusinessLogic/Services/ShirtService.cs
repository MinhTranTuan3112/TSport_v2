using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore;
using TSport.Api.BusinessLogic.Interfaces;
using TSport.Api.DataAccess.DTOs.Shirts;
using TSport.Api.DataAccess.Interfaces;

namespace TSport.Api.BusinessLogic.Services
{
    public class ShirtService : IShirtService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShirtService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetShirtDto>> GetShirts()
        {
            return await _unitOfWork.GetShirtRepository().Entities.ProjectToType<GetShirtDto>().ToListAsync();
        }
    }
}