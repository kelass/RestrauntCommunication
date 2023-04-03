using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using Restraunt.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {

            _context = context;

        }

        public Task<bool> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(Guid Id)
        {
            User user = await  _context.Users.FindAsync(Id);

            return user;
        }

        public async Task<IEnumerable<User>> Select()
        {
            return _context.Users;
        }
    }
}
