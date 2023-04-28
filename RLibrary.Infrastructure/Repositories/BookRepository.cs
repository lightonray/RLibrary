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
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext _context;

        public BookRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(Book entity)
        {
            _context.Books.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<Book> GetAsync(int? id)
        {
            return await _context.Books.AsQueryable()
                .Include(e => e.Price)
                .Include(e => e.Genre)
                .Where(e => e.Id == id)
                .SingleAsync();
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _context.Books.AsQueryable()
                 .Include(e => e.Price)
                 .Include(e => e.Genre)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetByGenreAsync(int? genreId)
        {
            return await _context.Books.AsQueryable()
               .Where(e => e.GenreId == genreId)
               .ToListAsync();
        }

        public async Task<int?> SaveAsync(Book entity)
        {
            await _context.Books.AddAsync(entity);
            return entity.Id;
        }

        public Task UpdateAsync(Book entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
