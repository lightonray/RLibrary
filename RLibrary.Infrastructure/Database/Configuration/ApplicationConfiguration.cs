﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RLibrary.Application.Services.Interfaces;
using RLibrary.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Infrastructure.Database.Configuration
{
    public static class ApplicationConfiguration
    {
            public static IServiceCollection AddDatabase(
                this IServiceCollection services,
                string connectionString,
                Assembly mappingAssembly)
            {
            services.AddDbContext<DatabaseContext>(opt =>
            {
                opt.UseSqlite(connectionString, config =>
                {
                    config.MigrationsAssembly(mappingAssembly.GetName().Name);
                    config.MigrationsHistoryTable("migration_history", "dbo");
                });

                opt.EnableDetailedErrors(true);
                opt.ConfigureWarnings(e =>
                {
                    e.Default(WarningBehavior.Log);
                });
            });


            services.AddRepositories();
                
                return services;
            }


            public static IServiceCollection AddRepositories(
               this IServiceCollection services)
            {
                services.AddScoped<IBookRepository, BookRepository>();
                services.AddScoped<IPriceRepository, PriceRepository>();
                services.AddScoped<IGenreRepository, GenreRepository>();
                services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
                services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

                return services;
            }

        public static IApplicationBuilder UseMigrations(this IApplicationBuilder app)
            {
                var database = app.ApplicationServices.CreateScope()
                    .ServiceProvider
                    .GetRequiredService<DatabaseContext>();

                database.Database.Migrate();

                return app;
            }
        }
    }

