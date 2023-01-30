using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restraunt.Core;

namespace Restraunt.Data.Configurations
{
    public class RolesConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role[]
            {
                 new Role{Id=new Guid("eb63b870-0675-4dbe-89d7-3e64bdb21f31"),Name="Admin",NormalizedName="ADMIN", ConcurrencyStamp="177db305-62ce-43b9-af2f-40e3616416de"},
                 new Role{Id=new Guid("a3dc9081-6dc1-4cf1-9e44-cefe22f97e85"),Name="User",NormalizedName="USER", ConcurrencyStamp="2913f171-7372-4b47-962a-2dd9928b882b"},
                 new Role{Id=new Guid("3a7b61fe-af28-4805-b7c2-e09e41fd7100"),Name="Waiter",NormalizedName="WAITER", ConcurrencyStamp="4a4dbcc1-3a72-42ff-935e-33e7bf199702"}
            });
        }
    }
}
