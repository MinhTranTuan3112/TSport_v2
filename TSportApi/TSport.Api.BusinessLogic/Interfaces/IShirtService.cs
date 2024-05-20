using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TSport.Api.DataAccess.DTOs.Query;
using TSport.Api.DataAccess.DTOs.Shirts;

namespace TSport.Api.BusinessLogic.Interfaces
{
    public interface IShirtService
    {
        Task<List<GetShirtDto>> GetShirts();
        
        Task<PagedResult<GetShirtInPagingResultDto>> GetPagedShirts(QueryPagedShirtsDto queryPagedShirtsDto);

        Task<GetShirtDetailDto> AddShirt(InsertShirtDto insertShirtDto, ClaimsPrincipal user);
    }
}