using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Mapster;
using Microsoft.EntityFrameworkCore;
using TSport.Api.BusinessLogic.Interfaces;
using TSport.Api.DataAccess.DTOs.Shirts;
using TSport.Api.DataAccess.Interfaces;
using TSport.Api.DataAccess.Models;

namespace TSport.Api.BusinessLogic.Services
{
    public class ShirtService : IShirtService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceFactory _serviceFactory;

        public ShirtService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetShirtDto>> GetShirts()
        {
            return await _unitOfWork.GetShirtRepository().Entities.ProjectToType<GetShirtDto>().ToListAsync();
        }

        public int CountShirts()
        {
            return _unitOfWork.GetShirtRepository().Entities.Count();
        }

        public async Task<List<GetShirtDto>> ViewShirts(
            string code, 
            string nameOfShirt, 
//            string nameOfPlayer, 
//            string season, 
            string status, 
            string sortedBy, 
            string sortOrder,
            int page
            )
        {
            List<Shirt> listShirtWithFilter = new List<Shirt>();
            List<Shirt> listShirtAfterSorted = new List<Shirt>();
            List<Shirt> listShirtAfterPaging = new List<Shirt>();

            // Get all shirts
            var listShirts = await _unitOfWork.GetShirtRepository().GetAllAsync();

            // Search by filter shirts by criterias (all of them)
            foreach(var shirt in listShirts)
            {
//                var playerOfShirt = _serviceFactory.get
                if (
                    (code is not null && shirt.Code.ToLower().Contains(code.ToLower()))
                    && (nameOfShirt is not null && shirt.Description.ToLower().Contains(nameOfShirt.ToLower()))
//                  Search theo hai cai nay tui add vao sau khi co GetPlayer/GetSeason
//                    && playerOfShirt.Contains(nameOfPlayer) 
//                    && playerOfShirt.Contains(seasone) 
                    && shirt.Status.Equals("Active")
                    )
                {
                    listShirtWithFilter.Add(shirt);
                }
            }

            // sort shirts by criterias (one of them)
            switch (sortedBy)
            {
                case "Code":
                    listShirtAfterSorted = sortOrder == "Descending"
                        ? listShirtWithFilter.OrderByDescending(s => s.Code).ToList()
                        : listShirtWithFilter.OrderBy(s => s.Code).ToList();
                    break;
                case "NameOfShirt":
                    listShirtAfterSorted = sortOrder == "Descending"
                        ? listShirtWithFilter.OrderByDescending(s => s.Description).ToList()
                        : listShirtWithFilter.OrderBy(s => s.Description).ToList();
                    break;
                case "ShirtEdition":
                    listShirtAfterSorted = sortOrder == "Descending"
                        ? listShirtWithFilter.OrderByDescending(s => s.ShirtEditionId).ToList()
                        : listShirtWithFilter.OrderBy(s => s.ShirtEditionId).ToList();
                    break;
/*
                case "NameOfPlayer":
                    listShirtAfterSorted = sortOrder == "Descending"
                        ? listShirtWithFilter.OrderByDescending(s => s.Code).ToList()
                        : listShirtWithFilter.OrderBy(s => s.Code).ToList();
                    break;
                case "Season":
                    listShirtAfterSorted = sortOrder == "Descending"
                        ? listShirtWithFilter.OrderByDescending(s => s.Code).ToList()
                        : listShirtWithFilter.OrderBy(s => s.Code).ToList();
                    break;
*/
                default:
                    listShirtAfterSorted = listShirtWithFilter;
                    break;
            }

            // paging
            listShirtAfterPaging = listShirtAfterSorted
                .Skip(10 * (page - 1))
                .Take(10)
                .ToList();

            // return
            return listShirtAfterPaging.Adapt<List<GetShirtDto>>();
        }
    }
}