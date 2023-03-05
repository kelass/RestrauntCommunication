using Restraunt.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Core.Interfaces
{
    public interface IOrderRepository:IBaseRepository<Order>
    {
        Task<bool> Create(OrderDto entity);
        Task<IEnumerable<Order>> SelectOrderUserId(Guid UserId);

    }
}
