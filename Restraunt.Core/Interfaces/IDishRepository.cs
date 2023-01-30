using Restraunt.Core;
using Restraunt.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Core.Interfaces
{
    public interface IDishRepository:IBaseRepository<Dish>
    {
        Task<bool> Create(DishDto entity);
    }
}
