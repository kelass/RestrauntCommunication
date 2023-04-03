using System;
using Microsoft.EntityFrameworkCore;
using Restraunt.Core.Interfaces;
using Restraunt.Data.Interfaces;
using Restraunt.Data.Repositories;

namespace Restraunt.Data
{
	public class UnitOfWork:IUnitOfWorks
	{
        private readonly ApplicationDbContext _db;
        private DishRepository _dishRepository;
        private TableRepository _tableRepository;
        private OrderRepository _orderRepository;
        private UserRepository _userRepository;

		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
		}

        

        public IDishRepository Dishes
        {
            get
            {
                return _dishRepository = _dishRepository?? new DishRepository(_db);
            }
        }

        public ITableRepository Tables
        {
            get
            {
                return _tableRepository = _tableRepository ?? new TableRepository(_db);
            }
        }


        public IOrderRepository Orders
        {
            get
            {
                return _orderRepository = _orderRepository ?? new OrderRepository(_db);
            }

        }  
        public IUserRepository Users
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_db);
            }

        }

        

        public async Task Save()
        {
          await _db.SaveChangesAsync();
        }


        
    }
}

