using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSport.Api.DataAccess.DTOs.Season
{
    public class GetSeasonDto
    {
        public int Id { get; set; }

        public string? Code { get; set; }

        public string? Name { get; set; }

        public int? ClubId { get; set; }
    }
}