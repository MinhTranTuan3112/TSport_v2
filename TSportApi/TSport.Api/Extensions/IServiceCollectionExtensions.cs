using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TSport.Api.DataAccess.Contexts;

namespace TSport.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithConfigurations()
                    .AddDbContextWithConfigurations(configuration)
                    .AddSwaggerConfigurations()
                    .AddCorsConfigurations();
            return services;
        }

        private static IServiceCollection AddDbContextWithConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            services.AddDbContext<TsportDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        private static IServiceCollection AddSwaggerConfigurations(this IServiceCollection services)
        {

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        private static IServiceCollection AddControllersWithConfigurations(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            return services;
        }

        private static IServiceCollection AddCorsConfigurations(this IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
            return services;
        }
    }
}