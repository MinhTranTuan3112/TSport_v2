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
        public async Task<GetShirtDetailDto> AddShirt(CreateShirtDto createShirtDto, ClaimsPrincipal user)
        {
            string? userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
            {
                throw new BadRequestException("User Unauthorized");
            }

            Shirt shirt = CreateShirtDto.Adapt<Shirt>();
            shirt.Status = "Active";
            shirt.CreatedAccountId = int.Parse(userId);
            shirt.CreatedDate = DateTime.Now;
            shirt.Id = CountShirt() + 1;  // tui thu bo cai nay r nhung ma chay api len no tra ve loi Id = null khong add vao DB duoc

            await _unitOfWork.GetShirtRepository().AddAsync(shirt);
            await _unitOfWork.SaveChangesAsync();

            return (await _unitOfWork.GetShirtRepository().GetByIdAsync(CountShirt())).Adapt<GetShirtDetailDto>();
        }
        private int CountShirt()
        {
            return _unitOfWork.GetShirtRepository().Entities.Count();
        }

    }
}