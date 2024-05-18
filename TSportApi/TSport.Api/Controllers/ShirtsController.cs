using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}