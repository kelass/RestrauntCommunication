using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using Restraunt.Core.Dto;
using Restraunt.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task<bool> Create(DishDto entity)
        {
            var result = new Dish { Id = entity.Id, Description= entity.Description, Name= entity.Name, Price= entity.Price };
            await _db.Dishes.AddAsync(result);

            return true;
        }

        public async Task<bool> Delete(Guid Id)
        {
            
            var entity = await _db.Dishes.Where(d => d.Id == Id).FirstOrDefaultAsync();
            if (entity != null)
            {
                _db.Remove<Dish>(entity);
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public async Task<Dish> Get(Guid Id)
        {
                var Dish = await _db.Dishes.Where(d => d.Id == Id).FirstOrDefaultAsync();

                return Dish;
        }

        public async Task<IEnumerable<Dish>> Select()
        {
            return _db.Dishes;
        }
    }
}
