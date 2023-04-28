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
    public sealed class ShoppingCartItemMapping : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable("shoppingcart_item", "dbo");

            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.BookId)
               .HasColumnName("book_id")
               .HasColumnType("INTEGER")
               .IsRequired();

            builder.Property(e => e.PriceId)
               .HasColumnName("price_id")
               .HasColumnType("INTEGER")
               .IsRequired();

            builder.Property(e => e.ShoppingCartId)
               .HasColumnName("shopping_cart_id")
               .HasColumnType("INTEGER")
               .IsRequired();

            builder.HasOne(e => e.Book)
                .WithMany()
                .HasForeignKey(e => e.BookId);

            builder.HasOne(e => e.Price)
                .WithMany()
                .HasForeignKey(e => e.PriceId);

            builder.HasOne(e => e.ShoppingCart)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.ShoppingCartId);


        }
    }
}
