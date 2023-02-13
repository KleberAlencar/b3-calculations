using MediatR;
using Microsoft.OpenApi.Models;
using Calculation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Calculation.Application.Queries.Handlers;

namespace Calculation.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Calculation.Api", Version = "v.1" });
            });
            
            services.AddDbContext<DataContext>(opt => {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddMediatR(typeof(GetCalculationRequestHandler));

            return services;
        }
    }
}