using AutoMapper;
using RLibrary.Application.Models;
using RLibrary.Application.Services.DTO;
using RLibrary.Application.Services.Interfaces;
using RLibrary.Application.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Application.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public GenreService(
            IMapper mapper,
            IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<long?> CreateGenreAsync(CreateUpdateGenreDTO createGenre)
        {
            var genre = Genre.Create(
               createGenre.Name);

            var genreId = await _genreRepository.SaveAsync(
                genre);

            return genreId;
        }

        public async Task DeleteGenreAsync(int? genreId)
        {
            if (genreId is null)
            {
                throw new ArgumentNullException(
                    nameof(genreId),
                    "Genre id is requred");
            }

            var genre = await _genreRepository.GetAsync(
                genreId);

            if (genre is null)
            {
                throw new ArgumentException(
                    $"Genre with id {genreId} does not exist",
                    nameof(genre));
            }

            await _genreRepository.DeleteAsync(genre);
        }

        public async Task<IEnumerable<GenreShortDTO>> GetGenreListAsync()
        {
            var genres = await _genreRepository.GetAsync();

            return _mapper.Map<IEnumerable<GenreShortDTO>>(genres);
        }

        public async Task UpdateGenreAsync(int? genreId, CreateUpdateGenreDTO updateGenre)
        {
            if (genreId is null)
            {
                throw new ArgumentNullException(
                    nameof(genreId),
                    "Genre id is requred");
            }

            var genre = await _genreRepository.GetAsync(
                genreId);

            if (genre is null)
            {
                throw new ArgumentException(
                    $"Product wit id {genreId} does not exist",
                    nameof(genre));
            }

            genre.Update(updateGenre.Name);

            await _genreRepository.UpdateAsync(genre);
        }
    }


    
}
