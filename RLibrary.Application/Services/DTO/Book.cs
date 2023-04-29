using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Application.Services.DTO
{
    public class Book
    {
        public sealed class CreateBookDTO
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public int Quanitity { get; set; }
            public int? GenreId { get; set; }
            public decimal PriceAmount { get; set; }
            public string PriceCurrency { get; set; }
        }

        public sealed class UpdateBookDTO
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public int Quanitity { get; set; }
        }


        public sealed class BookDetailsDTO
        {
            public int? BookId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Quanitity { get; set; }
            public string Price { get; set; }
        }

        public sealed class BookShortDTO
        {
            public int? BookId { get; set; }
            public string Title { get; set; }
            public string Price { get; set; }
        }

        public sealed class UpdateBookPriceDTO
        {
            public decimal PriceAmount { get; set; }
            public string PriceCurrency { get; set; }
        }

    }
}
