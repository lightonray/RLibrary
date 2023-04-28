using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RLibrary.Application.Services.DTO;
using RLibrary.Application.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RLibrary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(
           IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGenreAsync(
            CreateUpdateGenreDTO createGenre)
        {
            var genreId = await _genreService.CreateGenreAsync(createGenre);
            return Ok(genreId);
        }

        [HttpDelete("delete/{genreId}")]
        public async Task<IActionResult> DeleteGenreAsync(
            int? genreId)
        {
            await _genreService.DeleteGenreAsync(genreId);
            return Ok(genreId);
        }

        [HttpPatch("update/{genreId}")]
        public async Task<IActionResult> UpdateGenreAsync(
            int? genreId,
            CreateUpdateGenreDTO updateGenre)
        {
            await _genreService.UpdateGenreAsync(
                genreId,
                updateGenre);

            return Ok(genreId);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetGenreListAsync()
        {
            var genres = await _genreService.GetGenreListAsync();

            return Ok(genres);
        }
    }
}
