using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RLibrary.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Infrastructure.Database.Mappings
{
    public sealed class GenreMapping : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre", "dbo");

            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("TEXT")
                .HasMaxLength(254)
                .IsRequired();

            builder.HasMany(e => e.Books)
                .WithOne(e => e.Genre)
                .HasForeignKey(e => e.GenreId)
                .IsRequired();
        }
    }
}
