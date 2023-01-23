using Restraunt.Core;
using Restraunt.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Data.Interfaces
{
    public interface ITableRepository:IBaseRepository<Table>
    {
        Task<bool> Create(TableDto entity);
    }
}
