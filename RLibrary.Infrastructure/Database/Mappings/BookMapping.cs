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
    public sealed class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book", "dbo");

            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.Title)
                .HasColumnName("name")
                .HasColumnType("TEXT")
                .HasMaxLength(254)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("TEXT")
                .HasMaxLength(2049);

            builder.Property(e => e.FileId)
              .HasColumnName("file_id")
              .HasColumnType("TEXT")
              .HasMaxLength(32);

            builder.Property(e => e.GenreId)
                .HasColumnName("category_id")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.Property(e => e.PriceId)
               .HasColumnName("price_id")
               .HasColumnType("INTEGER")
               .IsRequired();

            builder.HasOne(e => e.Genre)
                .WithMany(e => e.Books)
                .HasForeignKey(e => e.GenreId);

            builder.HasOne(e => e.Price)
                .WithOne(e => e.Book)
                .HasForeignKey<Book>(e => e.PriceId)
                .IsRequired();

            builder.HasIndex(e => e.Title)
                .IsUnique();
        }
    }
}
