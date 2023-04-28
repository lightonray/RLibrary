using Microsoft.Extensions.DependencyInjection;
using RLibrary.Application.Services.Implementations;
using RLibrary.Application.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Application.Configurations
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddAutoMapper(
                Assembly.GetExecutingAssembly(),
                Assembly.GetEntryAssembly(),
                Assembly.GetCallingAssembly());

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IGenreService, GenreService>();

            return services;
        }
    }
}
