using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore;
using TSport.Api.BusinessLogic.Interfaces;
using TSport.Api.DataAccess.DTOs.Query;
using TSport.Api.DataAccess.DTOs.Shirts;
using TSport.Api.DataAccess.Interfaces;
using TSport.Api.Shared.Exceptions;

namespace TSport.Api.BusinessLogic.Services
{
    public class ShirtService : IShirtService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShirtService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<GetShirtInPagingResultDto>> GetPagedShirts(QueryPagedShirtsDto queryPagedShirtsDto)
        {
            if (queryPagedShirtsDto.StartPrice > queryPagedShirtsDto.EndPrice)
            {
                throw new BadRequestException("Start price must be smaller than end price");
            }


            return (await _unitOfWork.GetShirtRepository().GetPagedShirts(queryPagedShirtsDto)).Adapt<PagedResult<GetShirtInPagingResultDto>>();
        }

        public async Task<List<GetShirtDto>> GetShirts()
        {
            return await _unitOfWork.GetShirtRepository().Entities.ProjectToType<GetShirtDto>().ToListAsync();
        }
    }
}