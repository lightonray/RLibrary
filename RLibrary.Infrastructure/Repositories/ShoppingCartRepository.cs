using Microsoft.EntityFrameworkCore;
using RLibrary.Application.Models;
using RLibrary.Application.Services.Interfaces;
using RLibrary.Infrastructure.Database.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly DatabaseContext _context;

        public ShoppingCartRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(ShoppingCart entity)
        {
            _context.ShoppingCarts.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<ShoppingCart> GetAsync(int? id)
        {
            return await _context.ShoppingCarts.AsQueryable()
                .Where(e => e.Id == id)
                .SingleAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> GetAsync()
        {
            return await _context.ShoppingCarts.AsQueryable()
                .ToListAsync();
        }

        public async Task<int?> SaveAsync(ShoppingCart entity)
        {
            await _context.ShoppingCarts.AddAsync(entity);
            return entity.Id;
        }

        public Task UpdateAsync(ShoppingCart entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
