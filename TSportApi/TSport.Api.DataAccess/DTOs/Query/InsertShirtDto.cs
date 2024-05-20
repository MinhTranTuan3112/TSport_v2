﻿using System;
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
        public string? Code { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int? ShirtEditionId { get; set; }

        [Required]
        public int? SeasonPlayerId { get; set; }
    }
}
