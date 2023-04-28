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
    public class PriceRepository : IPriceRepository
    {
        private readonly DatabaseContext _context;
        public PriceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(Price entity)
        {
            _context.Prices.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<Price> GetAsync(int? id)
        {
            return await _context.Prices.AsQueryable()
               .Where(e => e.Id == id)
               .SingleAsync();
        }

        public async Task<IEnumerable<Price>> GetAsync()
        {
            return await _context.Prices.AsQueryable()
              .ToListAsync(); ;
        }

        public async Task<Price> GetByGenreAsync(int? bookId)
        {
            return await _context.Prices.AsQueryable()
               .Where(e => e.Book.Id == bookId)
               .FirstOrDefaultAsync();
        }

        public async Task<int?> SaveAsync(Price entity)
        {
            await _context.Prices.AddAsync(entity);
            return entity.Id;
        }

        public Task UpdateAsync(Price entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
