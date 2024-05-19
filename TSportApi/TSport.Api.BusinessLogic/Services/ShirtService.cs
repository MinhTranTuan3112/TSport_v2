using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore;
using TSport.Api.BusinessLogic.Interfaces;
using TSport.Api.DataAccess.DTOs.Query;
using TSport.Api.DataAccess.DTOs.Shirts;
using TSport.Api.DataAccess.Interfaces;
using TSport.Api.DataAccess.Models;
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

        public async Task<GetShirtDetailDTO> GetShirtDetail(int id)
        {

            return (await _unitOfWork.GetShirtRepository().GetShirtDetail(id)).Adapt<GetShirtDetailDTO>();
        }

        public async Task<GetShirtDetailDTO> CreateShirt(QueryShirtDto queryShirtDto, ClaimsPrincipal user)
        {
            string userId = "1";

            if (!(user.FindFirst(ClaimTypes.NameIdentifier)?.Value == null))
            {
                userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;    
            }
            else
            {
                throw new Exception("User Unauthorized");
            }

            Shirt shirt = queryShirtDto.Adapt<Shirt>();
            shirt.CreatedAccountId = int.Parse(userId);
            shirt.CreatedDate = DateTime.Now;
            shirt.Id = CountShirt() + 1;

            _unitOfWork.GetShirtRepository().CreateShirt(shirt);

            return await GetShirtDetail(shirt.Id);
        }
        private int CountShirt()
        {
            return _unitOfWork.GetShirtRepository().CountShirt();
        } 
    }
}