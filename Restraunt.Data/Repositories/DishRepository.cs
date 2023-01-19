using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using Restraunt.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Data.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationDbContext _db;
        public DishRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Dish entity)
        {
          await _db.AddAsync(entity);
          await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var entity = await _db.Dishes.Where(d => Id == Id).FirstOrDefaultAsync();
            _db.Remove(entity);
           await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Dish> Get(Guid Id)
        {
                var Dish = await _db.Dishes.Where(d => d.Id == Id).FirstOrDefaultAsync();

                return Dish;
        }

        public Task<List<Dish>> Select()
        {
            return _db.Dishes.ToListAsync();
        }
    }
}
