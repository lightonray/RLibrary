using AutoMapper;
using RLibrary.Application.Models;
using RLibrary.Application.Services.Interfaces;
using RLibrary.Application.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RLibrary.Application.Services.DTO.Book;

namespace RLibrary.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BookService(
            IMapper mapper,
            IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<long?> CreateBookAsync(
            CreateBookDTO createBook)
        {


            var price = new Price(
                createBook.PriceAmount,
                createBook.PriceCurrency);



            var book = Book.Create(
                createBook.Title,
                createBook.Description,
                createBook.GenreId,
                createBook.Quanitity,
                price);

       

            var bookId = await _bookRepository.SaveAsync(
                book);

            return bookId;
        }


        public async Task UpdateBookPriceAsync(
           int? bookId,
           UpdateBookPriceDTO updateBookPrice)
        {
            if (bookId is null)
            {
                throw new ArgumentNullException(
                    nameof(bookId),
                    "Book id is requred");
            }

            var book = await _bookRepository.GetAsync(
                bookId);

            if (book is null)
            {
                throw new ArgumentException(
                    $"book with id {bookId} does not exist",
                    nameof(book));
            }

            var newPrice = new Price(
                updateBookPrice.PriceAmount,
                updateBookPrice.PriceCurrency);


            book.ChangePrice(newPrice);

            await _bookRepository.UpdateAsync(book);
        }


        public async Task UpdateBookAsync(
          int? bookId,
          UpdateBookDTO updateBook)
        {
            if (bookId is null)
            {
                throw new ArgumentNullException(
                    nameof(bookId),
                    "book id is requred");
            }

            var book = await _bookRepository.GetAsync(
                bookId);

            if (book is null)
            {
                throw new ArgumentException(
                    $"book with id {bookId} does not exist",
                    nameof(book));
            }


            book.Update(
                updateBook.Title,
                updateBook.Description,
                updateBook.Quanitity);

            await _bookRepository.UpdateAsync(book);
        }

        public async Task<BookDetailsDTO> GetBookDetailsAsync(
            int? bookId)
        {
            if (bookId is null)
            {
                throw new ArgumentNullException(
                    nameof(bookId),
                    "Book id is requred");
            }

            var book = await _bookRepository.GetAsync(
                bookId);

            if (book is null)
            {
                throw new ArgumentException(
                    $"Book with id {bookId} does not exist",
                    nameof(book));
            }

            return _mapper.Map<BookDetailsDTO>(book);
        }

        public async Task DeleteBookAsync(
            int? bookId)
        {
            if (bookId is null)
            {
                throw new ArgumentNullException(
                    nameof(bookId),
                    "book id is requred");
            }

            var book = await _bookRepository.GetAsync(
                bookId);

            if (book is null)
            {
                throw new ArgumentException(
                    $"book with id {bookId} does not exist",
                    nameof(book));
            }

            await _bookRepository.DeleteAsync(book);
        }



        public async Task<IEnumerable<BookShortDTO>> GetBookListAsync(
           int? genreId)
        {
            var books = genreId == null
                ? await _bookRepository.GetAsync()
                : await _bookRepository.GetByGenreAsync(genreId);

            return _mapper.Map<IEnumerable<BookShortDTO>>(books);
        }


    }
}
