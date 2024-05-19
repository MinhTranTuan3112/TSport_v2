using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TSport.Api.DataAccess.DTOs.Query
{
    public class QueryPagedShirtsDto
    {
        [Required]
        public int PageNumber { get; set; } = 1;

        [Required]
        public int PageSize { get; set; } = 9;

        public string SortColumn { get; set; } = "id";

        public bool OrderByDesc { get; set; } = true;

        public QueryShirtDto? QueryShirtDto { get; set; }

        public decimal StartPrice { get; set; }

        public decimal EndPrice { get; set; }
    }
}