using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSport.Api.DataAccess.DTOs.Auth
{
    public class GetAuthTokensDto
    {
        public required string AccessToken { get; set; }

        public required string RefreshToken { get; set; }
    }
}