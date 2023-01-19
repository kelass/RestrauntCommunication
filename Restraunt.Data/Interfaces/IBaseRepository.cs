using Restraunt.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Data.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<bool> Delete(Guid Id);
        
        Task<List<T>> Select();
        Task<T> Get(Guid Id);
    }
}
