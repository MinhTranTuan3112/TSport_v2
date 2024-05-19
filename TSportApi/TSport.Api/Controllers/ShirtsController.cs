using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TSport.Api.BusinessLogic.Interfaces;
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
        public async Task<ActionResult<List<GetShirtDto>>> GetShirts()
        {
            return await _serviceFactory.GetShirtService().GetShirts();
        }

        [HttpGet]
        public async Task<ActionResult<List<GetShirtDto>>> ViewShirts(
            string code,
            string nameOfShirt,
//            string nameOfPlayer, 
//            string season, 
            string status,
            string sortedBy,
            string sortOrder,
            int page
            )
        {
            var result = await _serviceFactory.GetShirtService().ViewShirts(code, nameOfShirt, status, sortedBy, sortOrder, page);
            return Ok(result);
        }

    }
}