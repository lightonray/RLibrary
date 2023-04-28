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
            public string Title { get; }
            public string Description { get;  }
            public int Quanitity { get;  }
            public int? GenreId { get;  }
            public decimal PriceAmount { get;  }
            public string PriceCurrency { get;  }
        }

        public sealed class UpdateBookDTO
        {
            public string Title { get; }
            public string Description { get; }
            public int Quanitity { get; }
        }


        public sealed class BookDetailsDTO
        {
            public int? BookId { get; }
            public string Title { get; }
            public string Description { get; }
            public int Quanitity { get; }
            public string Price { get; }
        }

        public sealed class BookShortDTO
        {
            public int? BookId { get; }
            public string Title { get; }
            public string Price { get; }
        }

        public sealed class UpdateBookPriceDTO
        {
            public decimal PriceAmount { get; }
            public string PriceCurrency { get; }
        }

    }
}
