using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [HttpGet("ViewShirts/{page}")]
        public async Task<ActionResult<List<GetShirtDto>>> ViewShirts(
            string? keyWord,
//            string nameOfPlayer, 
//            string season, 
            [DefaultValue("Code or NameOfShirt or ShirtEdition")] string? sortedBy,
            [DefaultValue("Default is Ascending")] string? sortOrder,
            int page
            )
        {
            var result = await _serviceFactory.GetShirtService().ViewShirts(keyWord, sortedBy, sortOrder, page);
            return Ok(result);
        }

    }
}