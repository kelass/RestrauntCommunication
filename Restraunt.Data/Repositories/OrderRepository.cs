using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using Restraunt.Core.Dto;
using Restraunt.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(OrderDto entity)
        {
            User user = await _db.Users.FirstOrDefaultAsync(u => u.Id == entity.UserId);
            if (user != null)
            {
                var result = new Order { Id = entity.Id, Message = entity.Message, TableName = entity.TableName, User = user };
                await _db.Orders.AddAsync(result);

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid Id)
        {
            var entity = await _db.Orders.Where(d => d.Id == Id).FirstOrDefaultAsync();
            if (entity != null)
            {
                _db.Remove<Order>(entity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Order> Get(Guid Id)
        {
            Order? entity = await _db.Orders.Include(u => u.User).Where(d => d.Id == Id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<IEnumerable<Order>> Select()
        {
            return _db.Orders.Include(u => u.User);
        }

        public async Task<IEnumerable<Order>> SelectOrderUserId(Guid UserId)
        {
            return _db.Orders.Where(o => o.User.Id == UserId);
        }
    }
}
