using Cella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Domain.Interfaces
{
    public interface IGenericService<TViewModel, TEntity>
        where TEntity : class, new()
    {
        Task<ServiceResponse<IEnumerable<TEntity>>> GetAllAsync();
        Task<ServiceResponse<TEntity>> GetByIdAsync(int id);
        Task<ServiceResponse<string>> AddAsync(TViewModel viewModel);
        Task<ServiceResponse<string>> UpdateAsync(TViewModel viewModel);
        Task<ServiceResponse<string>> DeleteAsync(int id);
    }


}
