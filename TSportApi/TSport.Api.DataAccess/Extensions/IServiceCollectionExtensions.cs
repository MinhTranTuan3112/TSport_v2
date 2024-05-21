using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TSport.Api.DataAccess.Interfaces;
using TSport.Api.DataAccess.Repositories;

namespace TSport.Api.DataAccess.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services)
        {
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IShirtRepository, ShirtRepository>();
            services.AddScoped<IAccountRepository, AccountRepositoy>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}