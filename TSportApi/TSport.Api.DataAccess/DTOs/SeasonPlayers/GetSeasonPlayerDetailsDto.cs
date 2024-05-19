using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSport.Api.DataAccess.DTOs.Players;
using TSport.Api.DataAccess.DTOs.Season;

namespace TSport.Api.DataAccess.DTOs.SeasonPlayers
{
    public class GetSeasonPlayerDetailsDto
    {
        public int Id { get; set; }

        public int SeasonId { get; set; }

        public int PlayerId { get; set; }

        public GetPlayerDto Player { get; set; } = null!;

        public GetSeasonDto Season { get; set; } = null!;
    }
}