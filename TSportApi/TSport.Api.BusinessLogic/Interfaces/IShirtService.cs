using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSport.Api.DataAccess.DTOs.Shirts;

namespace TSport.Api.BusinessLogic.Interfaces
{
    public interface IShirtService
    {
        Task<List<GetShirtDto>> GetShirts();
    }
}