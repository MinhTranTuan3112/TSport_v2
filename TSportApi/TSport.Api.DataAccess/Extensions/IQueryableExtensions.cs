using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TSport.Api.DataAccess.DTOs.Query;
using TSport.Api.DataAccess.DTOs.Shirts;
using TSport.Api.DataAccess.Models;

namespace TSport.Api.DataAccess.Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<PagedResult<T>> ToPagniationListAsync<T>(this IQueryable<T> query, int pageNumber = 1, int pageSize = 9)
          where T : class
        {
            int totalCount = await query.CountAsync();

            var items = await query.ToListAsync();

            return new PagedResult<T>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
                Items = items
            };
        }


        public static IQueryable<Shirt> ApplyPagedShirtsFilter(this IQueryable<Shirt> query,
        QueryPagedShirtsDto queryPagedShirtsDto)
        {

            if (queryPagedShirtsDto.StartPrice < queryPagedShirtsDto.EndPrice)
            {
                query = query.Where(s => s.ShirtEdition != null && s.ShirtEdition.Price >= queryPagedShirtsDto.StartPrice &&
                                        s.ShirtEdition.Price <= queryPagedShirtsDto.EndPrice);
            }


            var filterProperties = typeof(QueryShirtDto).GetProperties();
            foreach (var property in filterProperties)
            {
                var propertyValue = property.GetValue(queryPagedShirtsDto.QueryShirtDto, null);

                if (propertyValue is null)
                {
                    continue;
                }


                if (property.PropertyType == typeof(string))
                {
                    var filterValueLower = ((string)propertyValue).ToLower();

                    query = query.Where(s => EF.Property<string>(s, property.Name).ToLower().Contains(filterValueLower));
                }
                else
                {
                    query = query.Where(s => EF.Property<object>(s, property.Name) == propertyValue);
                }
            }



            return query;
        }
    }
}