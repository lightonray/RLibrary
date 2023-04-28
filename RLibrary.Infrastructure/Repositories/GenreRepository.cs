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
    public class GenreRepository : IGenreRepository
    {
        private readonly DatabaseContext _context;

        public GenreRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(Genre entity)
        {
            _context.Genres.Remove(entity);
            return Task.CompletedTask; ;
        }

        public async Task<Genre> GetAsync(int? id)
        {
            return await _context.Genres.AsQueryable()
                .Where(e => e.Id == id)
                .SingleAsync();
        }

        public Task<IEnumerable<Genre>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int?> SaveAsync(Genre entity)
        {
            await _context.Genres.AddAsync(entity);
            return entity.Id;
        }

        public Task UpdateAsync(Genre entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
