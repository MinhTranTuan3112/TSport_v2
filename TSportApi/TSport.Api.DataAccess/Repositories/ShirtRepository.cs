using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore;
using TSport.Api.DataAccess.Contexts;
using TSport.Api.DataAccess.DTOs.Query;
using TSport.Api.DataAccess.DTOs.Shirts;
using TSport.Api.DataAccess.Extensions;
using TSport.Api.DataAccess.Interfaces;
using TSport.Api.DataAccess.Models;

namespace TSport.Api.DataAccess.Repositories
{
    public class ShirtRepository : GenericRepository<Shirt>, IShirtRepository
    {
        private readonly TsportDbContext _context;
        public ShirtRepository(TsportDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedResult<Shirt>> GetPagedShirts(QueryPagedShirtsDto queryPagedShirtsDto)
        {
            int pageNumber = queryPagedShirtsDto.PageNumber;
            int pageSize = queryPagedShirtsDto.PageSize;
            string sortColumn = queryPagedShirtsDto.SortColumn;
            bool sortByDesc = queryPagedShirtsDto.OrderByDesc;

            //Query
            var query = _context.Shirts
                                    .AsNoTracking()
                                    .Include(s => s.ShirtEdition)
                                    .Include(s => s.SeasonPlayer)
                                        .ThenInclude(sp => sp.Player)
                                    .Include(s => s.SeasonPlayer)
                                        .ThenInclude(sp => sp.Season)
                                    .AsQueryable();

            //Filter
            if (queryPagedShirtsDto.QueryShirtDto is not null)
            {
                // query = query.ApplyPagedShirtsFilter(queryPagedShirtsDto);
                query = query.ApplyPagedShirtsFilter(queryPagedShirtsDto);
            }

            //Sort
            query = sortByDesc ? query.OrderByDescending(TestGetSortProperty(sortColumn))
                                : query.OrderBy(TestGetSortProperty(sortColumn));

            //Paging
            return await query.ToPagniationListAsync(pageNumber, pageSize);

        }

        private Expression<Func<Shirt, object>> TestGetSortProperty(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "code" => shirt => (shirt.Code == null) ? shirt.Id : shirt.Code,
                "description" => shirt => (shirt.Description == null) ? shirt.Id : shirt.Description,
                "status" => shirt => (shirt.Status == null) ? shirt.Id : shirt.Status,
                "createddate" => shirt => shirt.CreatedDate,
                _ => shirt => shirt.Id,
            };
        }

        private Expression<Func<GetShirtInPagingResultDto, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "code" => shirt => (shirt.Code == null) ? shirt.Id : shirt.Code,
                "description" => shirt => (shirt.Description == null) ? shirt.Id : shirt.Description,
                "status" => shirt => (shirt.Status == null) ? shirt.Id : shirt.Status,
                "createddate" => shirt => shirt.CreatedDate,
                _ => shirt => shirt.Id,
            };
        }
        public Task<Shirt> GetShirtDetail(int id) 
        {
            var query = _context.Shirts
                .AsNoTracking()
                .Include(s => s.ShirtEdition)
                .Include(s => s.SeasonPlayer)
                    .ThenInclude(sp => sp.Player)
                .Include(s => s.SeasonPlayer)
                    .ThenInclude(sp => sp.Season)
                        .ThenInclude(se => se.Club)
                .SingleOrDefaultAsync(s => s.Id == id);

            return query;
        } 
    }
}