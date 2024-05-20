using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSport.Api.DataAccess.DTOs.Query
{
    public class InsertShirtDto
    {
        [Required]
        [RegularExpression("^SRT\\d{3}$")]
        public string? Code { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        [RegularExpression("^\\d+$")]
        public int? ShirtEditionId { get; set; }

        [Required]
        [RegularExpression("^\\d+$")]
        public int? SeasonPlayerId { get; set; }
    }
}
