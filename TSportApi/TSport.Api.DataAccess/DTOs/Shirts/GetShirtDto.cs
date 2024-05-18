using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSport.Api.DataAccess.DTOs.ShirtEditions;

namespace TSport.Api.DataAccess.DTOs.Shirts
{
    public class GetShirtDto
    {
        public int Id { get; set; }

        public string? Code { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }

        public int? ShirtEditionId { get; set; }

        public int? SeasonPlayerId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedAccountId { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedAccountId { get; set; }


        public GetShirtEditionDto? ShirtEdition { get; set; }
    }
}