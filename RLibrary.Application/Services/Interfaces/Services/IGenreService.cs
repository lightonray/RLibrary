using RLibrary.Application.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Application.Services.Interfaces.Services
{
    public interface IGenreService
    {
        Task<long?> CreateGenreAsync(CreateUpdateGenreDTO createGenre);
        Task DeleteGenreAsync(int? genreId);
        Task<IEnumerable<GenreShortDTO>> GetGenreListAsync();
        Task UpdateGenreAsync(int? GenreId, CreateUpdateGenreDTO updateGenre);
    }
}
