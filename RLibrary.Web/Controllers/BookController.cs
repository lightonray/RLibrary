using Microsoft.AspNetCore.Mvc;
using RLibrary.Application.Services.Interfaces.Services;
using Swagger.Net.Annotations;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RLibrary.Application.Services.DTO.Book;


namespace RLibrary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("create")]
        
        public async Task<IActionResult> CreateBookAsync(
         [FromBody] CreateBookDTO createBook)
        {

            var bookId = await _bookService.CreateBookAsync(createBook);

            return Ok(bookId);


        }
   

        [HttpDelete("delete/{bookId}")]
        public async Task<IActionResult> DeleteProductAsync(
            int? bookId)
        {
            await _bookService.DeleteBookAsync(bookId);
            return Ok(bookId);
        }

        [HttpPatch("update/{bookId}")]
        public async Task<IActionResult> UpdateBookAsync(
            int? bookId,
            UpdateBookDTO updateBook)
        {
            await _bookService.UpdateBookAsync(
                bookId,
                updateBook);

            return Ok(bookId);
        }

        [HttpPost("update/{bookId}/price")]
        public async Task<IActionResult> UpdateProductPriceAsync(
           int? bookId,
           UpdateBookPriceDTO updateBookPrice)
        {
            await _bookService.UpdateBookPriceAsync(
                bookId,
                updateBookPrice);

            return Ok(bookId);
        }

        [HttpGet("detail/{bookId}")]
        public async Task<IActionResult> GetBookDetailsAsync(
            int? bookId)
        {
            var book = await _bookService.GetBookDetailsAsync(
               bookId);

            return Ok(book);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetProductListAsync(
            [FromQuery] int? genreId)
        {
            var products = await _bookService.GetBookListAsync(
                genreId);

            return Ok(products);
        }


       
    }
}
