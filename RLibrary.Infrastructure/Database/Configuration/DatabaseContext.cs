using Microsoft.EntityFrameworkCore;
using RLibrary.Application.Models;
using RLibrary.Infrastructure.Database.Mappings;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Infrastructure.Database.Configuration
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext([NotNull] DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
               typeof(BookMapping).Assembly);

            var category1 = Genre.Create("Other");
            category1.Id = 1;

            modelBuilder.Entity<Genre>()
                .HasData(category1);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=main.db", config =>
                {
                    config.MigrationsAssembly("RLibrary.Infrastructure");
                    config.MigrationsHistoryTable("migration_history", "dbo");
                });

                optionsBuilder.EnableDetailedErrors(true);
                optionsBuilder.ConfigureWarnings(e =>
                {
                    e.Default(WarningBehavior.Log);
                });
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
