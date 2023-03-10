using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using Restraunt.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Data
{
    public class ApplicationDbContext:IdentityDbContext<User,Role,Guid>
    {
       public DbSet<Dish> Dishes { get; set; }
       public DbSet<Table> Tables { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<Role> Roles { get; set; }
       public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, string m) : base(options) { Database.EnsureCreated(); }
        



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);


            modelbuilder.ApplyConfiguration(new RolesConfiguration());

        }
    }
}
