using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSport.Api.BusinessLogic.Interfaces;
using TSport.Api.DataAccess.DTOs.Query;
using TSport.Api.DataAccess.DTOs.Shirts;

namespace TSport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public ShirtsController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }


        [HttpGet]
        public async Task<ActionResult<PagedResult<GetShirtInPagingResultDto>>> GetPagedShirts(
            [FromQuery] QueryShirtDto query,
            decimal startPrice,
            decimal endPrice,
            int pageNumber = 1,
            int pageSize = 9,
            string sortColumn = "id",
            bool orderByDesc = true)
        {
            return await _serviceFactory.GetShirtService().GetPagedShirts(new QueryPagedShirtsDto
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SortColumn = sortColumn,
                OrderByDesc = orderByDesc,
                QueryShirtDto = query,
                StartPrice = startPrice,
                EndPrice = endPrice
            });
        }

        [HttpGet("ViewShirtDetail/{id}")]
        public async Task<ActionResult<GetShirtDetailDTO>> ViewShirtDetail(int id)
        {
            return await _serviceFactory.GetShirtService().GetShirtDetail(id);
        }

        [HttpPost("CreateShirt")]
        public async Task<ActionResult<GetShirtDetailDTO>> CreateShirt(QueryShirtDto queryShirtDto)
        {
            return await _serviceFactory.GetShirtService().CreateShirt(queryShirtDto, User);
        }
    }
}