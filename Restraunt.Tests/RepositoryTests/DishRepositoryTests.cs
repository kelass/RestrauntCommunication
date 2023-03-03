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
using Restraunt.Tests.TestHelper;

namespace Restraunt.Tests.RepositoryTests
{
    public class DishRepositoryTests
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly DishRepository _dishRepository;

        public DishRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()

            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            _dbContext = new ApplicationDbContext(options, "test");
            _dishRepository = new DishRepository(_dbContext);
        }

       

        [Test]
        public async Task Create_ShouldAddDishToDatabase()
        {
            // Arrange
            var dishDto = new DishDto { Id = Guid.Parse("9d64af9b-de56-43a7-94a1-f4cf169b7b35"), Description = "Test Dish", Name = "Test", Price = 10 };
            

            // Act
            var result = await _dishRepository.Create(dishDto);

            _dbContext.SaveChanges();
            // Assert
            Assert.IsTrue(result);
            
        }

        [Test]

        public async Task Delete_ShouldDeleteDishToDatabase_Success()
        {
            // Arrange
            Create_ShouldAddDishToDatabase();

            Guid Id = Guid.Parse("9d64af9b-de56-43a7-94a1-f4cf169b7b35");


            // Act
            var result = await _dishRepository.Delete(Id);
            _dbContext.SaveChanges();
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task Delete_ShouldDeleteDishToDatabase_NotSuccess()
        {
            // Arrange
            
            Guid Id = Guid.Parse("9d64af9b-de56-43a7-94a1-f4cf169b7b36");


            // Act
            var result = await _dishRepository.Delete(Id);
            
            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task SelectAllDishes()
        {
            //Arrange
            var dish = FakeDataBogus.GenerateOneDish();
            _dbContext.Add(dish);
            _dbContext.SaveChanges();

            //Act 
            var result = await _dishRepository.Select();

            //Assert
            Assert.AreEqual(_dbContext.Dishes.Count(), result.Count());
        }
        [Test]
        public async Task GetDishById_False()
        {
            //Arrange
            await Create_ShouldAddDishToDatabase();
            Guid Id = Guid.Parse("9d64af9b-de56-43a7-94a1-f4cf169b7b35");

            //Act 
            var result = await _dishRepository.Get(Id);


            //Assert
            Assert.AreEqual(Id, result.Id);
        }

    }
}
