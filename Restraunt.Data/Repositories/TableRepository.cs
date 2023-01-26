﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Restraunt.Core;
using Restraunt.Core.Dto;
using Restraunt.Core.Interfaces;
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
        public async Task<bool> Create(TableDto entity)
        {
            var result = new Table { Id = entity.Id, Name = entity.Name, Link = entity.Link, User = entity.User };
            await _db.Tables.AddAsync(result);
            

            return true;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var entity = await _db.Tables.Where(t => t.Id == Id).FirstOrDefaultAsync();
            _db.Tables.Remove(entity);

            
            return true;
        }

        public async Task<Table> Get(Guid id)
        {
            var table = await _db.Tables.Where(t => t.Id == id).FirstOrDefaultAsync();

            return table;
        }

        public async Task<IEnumerable<Table>> Select()
        {
            return _db.Tables;
        }
    }
}
