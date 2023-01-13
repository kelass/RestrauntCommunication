using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Data
{
    class ApplicationDbContext:DbContext
    {
        DbSet<Dish> Dishes { get; set; }
        DbSet<Table> Tables { get; set; }


        // Migrate DB

    }
}
