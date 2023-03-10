using Microsoft.EntityFrameworkCore;
using Restraunt.Data.Repositories;
using Restraunt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restraunt.Core.Dto;
using Restraunt.Core.Interfaces;
using Restraunt.Tests.TestHelper;
using Restraunt.Core;

namespace Restraunt.Tests.RepositoryTests
{
    public class TableRepositoryTests
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly TableRepository _tableRepository;

        public TableRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()

            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            _dbContext = new ApplicationDbContext(options, "test");
            _tableRepository = new TableRepository(_dbContext);
        }

        [Test]
        public async Task Create_ShouldAddTableToDatabase_Success()
        {
            // Arrange
            var dish = FakeDataBogus.GenerateOneTable();

            
            
            // Act
            var result = await _tableRepository.Create(dish);
            _dbContext.SaveChanges();
            // Assert
            Assert.IsTrue(result);

        }


        [Test]
        public async Task DeleteTable_Success()
        {
            // Arrange
            
            var Id = Guid.Parse("d11c14e0-323e-4176-b269-fd799ba4da6a");

            // Act
            var result = await _tableRepository.Delete(Id);
            
            // Assert
            Assert.IsTrue(result);

        }

        [Test]
        public async Task DeleteTable_NotSuccess()
        {
            // Arrange
            Create_ShouldAddTableToDatabase_Success();

            var Id = Guid.Parse("d11c14e0-323e-4176-b269-fd799ba4da6c");

            // Act
            var result = await _tableRepository.Delete(Id);
            _dbContext.SaveChanges();

            // Assert
            Assert.AreEqual(false, result);

        }


        [Test]
        public async Task GetTableById_Success()
        {
            // Arrange
            Create_ShouldAddTableToDatabase_Success();

            var Id = Guid.Parse("d11c14e0-323e-4176-b269-fd799ba4da6a");

            // Act
            var result = await _tableRepository.Get(Id);
            

            // Assert
            Assert.AreEqual(Id,result.Id);

        }


        [Test]
        public async Task SelectTables_Success()
        {
            // Arrange
            Create_ShouldAddTableToDatabase_Success();

            

            // Act
            var result = await _tableRepository.Select();


            // Assert
            Assert.AreEqual(_dbContext.Tables.Count(), result.Count());

        }

        [Test]
        public async Task BindUserToTable_Success()
        {
            //Arrange
            var user = FakeDataBogus.GenerateRestrauntUser();

            var table = new Table { Id = Guid.Parse("9ef94f67-1753-4957-a686-14211a1d0cfc"), Link="Test", Name= "Test", User=null };
            BindUserToTableDto dto = new BindUserToTableDto { Id=table.Id, UserId=user.Id };
            _dbContext.Add(table);
            _dbContext.Add(user);
            _dbContext.SaveChanges();

            bool key = false;
            //Act

            var result = await _tableRepository.BindUserToTable(dto);

            if (result != null)
            {
                key = true;
            }
            else
            {
                key = false;
            }

            //Assert

            Assert.True(key);

        }

    }
}
