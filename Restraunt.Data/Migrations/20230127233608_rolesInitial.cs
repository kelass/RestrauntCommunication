using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restraunt.Data.Migrations
{
    /// <inheritdoc />
    public partial class rolesInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3a7b61fe-af28-4805-b7c2-e09e41fd7100"), "4a4dbcc1-3a72-42ff-935e-33e7bf199702", "Waiter", "WAITER" },
                    { new Guid("a3dc9081-6dc1-4cf1-9e44-cefe22f97e85"), "2913f171-7372-4b47-962a-2dd9928b882b", "User", "USER" },
                    { new Guid("eb63b870-0675-4dbe-89d7-3e64bdb21f31"), "177db305-62ce-43b9-af2f-40e3616416de", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3a7b61fe-af28-4805-b7c2-e09e41fd7100"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a3dc9081-6dc1-4cf1-9e44-cefe22f97e85"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eb63b870-0675-4dbe-89d7-3e64bdb21f31"));
        }
    }
}
