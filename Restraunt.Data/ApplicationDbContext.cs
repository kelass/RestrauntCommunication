using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Data
{
    public class ApplicationDbContext:DbContext
    {
       public DbSet<Dish> Dishes { get; set; }
       public DbSet<Table> Tables { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<Role> Roles { get; set; }


        // Migrate DB

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

            Database.Migrate();
        }
    }
}
