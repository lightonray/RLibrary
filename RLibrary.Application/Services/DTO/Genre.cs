using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Application.Services.DTO
{

    public sealed class CreateUpdateGenreDTO
    {
        public string Name { get; set; }
    }

    public sealed class GenreShortDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
