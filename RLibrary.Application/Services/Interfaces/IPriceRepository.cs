using RLibrary.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Application.Services.Interfaces
{
    public interface IPriceRepository : IRepository<Price>
    {
        Task<Price> GetByGenreAsync(int? productId);
    }
}
