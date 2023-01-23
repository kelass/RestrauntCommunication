using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Restraunt.Core;
using Restraunt.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Data.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly ApplicationDbContext _db;
        public TableRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Table entity)
        {
            await _db.Tables.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var entity = await _db.Tables.Where(t => t.Id == Id).FirstOrDefaultAsync();
            _db.Tables.Remove(entity);

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Table> Get(Guid id)
        {
            var table = await _db.Tables.Where(t => t.Id == id).FirstOrDefaultAsync();

            return table;
        }

        public async Task<List<Table>> Select()
        {
            return await _db.Tables.ToListAsync();
        }
    }
}
