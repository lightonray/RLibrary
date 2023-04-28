using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLibrary.Application.Services.Interfaces
{
    public interface IRepository<TEntity> 
    {
        Task<TEntity> GetAsync(int? id);

        Task<IEnumerable<TEntity>> GetAsync();

        Task<int?> SaveAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
