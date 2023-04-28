using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RLibrary.Application.Services.DTO.Book;

namespace RLibrary.Application.Services.Interfaces.Services
{
    public interface IBookService
    {
        Task<long?> CreateBookAsync(
                CreateBookDTO createBook);

        Task UpdateBookAsync(
        int? bookId,
        UpdateBookDTO updateBook);

        Task DeleteBookAsync(
        int? bookId);

        Task UpdateBookPriceAsync(
            int? bookId,
            UpdateBookPriceDTO updateBookPrice);

        Task<BookDetailsDTO> GetBookDetailsAsync(
            int? bookId);

        Task<IEnumerable<BookShortDTO>> GetBookListAsync(
            int? genreId);
    }
}
