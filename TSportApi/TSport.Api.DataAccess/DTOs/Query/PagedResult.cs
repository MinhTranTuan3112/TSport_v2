using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSport.Api.DataAccess.DTOs.Query
{
    public class PagedResult<T> where T : class
    {
        public int TotalCount { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public List<T> Items { get; set; } = [];
    }
}