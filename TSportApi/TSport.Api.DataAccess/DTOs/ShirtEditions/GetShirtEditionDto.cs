using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSport.Api.DataAccess.DTOs.ShirtEditions
{
    public class GetShirtEditionDto
    {
        public int Id { get; set; }

        public string? Code { get; set; }

        public string? Size { get; set; }

        public bool? HasSignature { get; set; }

        public decimal? Price { get; set; }

        public string? Color { get; set; }

        public string? Status { get; set; }

        public string? Origin { get; set; }

        public string? Material { get; set; }

        public int SeasonId { get; set; }
    }
}