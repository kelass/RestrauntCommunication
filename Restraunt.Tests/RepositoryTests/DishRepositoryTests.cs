using Moq;
using Restraunt.Core.Dto;
using Restraunt.Core;
using Restraunt.Data;
using Restraunt.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Restraunt.Tests.RepositoryTests
{
    public class DishRepositoryTests
    {

        ApplicationDbContext _dbContext;
        private DishRepository _dishRepository;

        
        [SetUp]
        public void Setup()
        {
             var options = new DbContextOptionsBuilder<ApplicationDbContext>()
             
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            _dbContext =new ApplicationDbContext(options);
            _dishRepository = new DishRepository(_dbContext);
        }

        [Test]
        public async Task Create_ShouldAddDishToDatabase()
        {
            // Arrange
            var dishDto = new DishDto { Id = Guid.NewGuid(), Description = "Test Dish", Name = "Test", Price = 10 };

            // Act
            var result = await _dishRepository.Create(dishDto);

            // Assert
            Assert.IsTrue(result);
            
        }
    }
}
