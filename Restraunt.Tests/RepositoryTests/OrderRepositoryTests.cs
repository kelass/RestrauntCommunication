using Microsoft.EntityFrameworkCore;
using Restraunt.Data.Repositories;
using Restraunt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restraunt.Core.Interfaces;
using Restraunt.Core.Dto;
using Restraunt.Tests.TestHelper;

namespace Restraunt.Tests.RepositoryTests
{
    public class OrderRepositoryTests
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly OrderRepository _orderRepository;

        public OrderRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()

           .UseInMemoryDatabase(databaseName: "TestDatabase")
           .Options;
            _dbContext = new ApplicationDbContext(options, "test");

            _orderRepository = new OrderRepository(_dbContext);
        }

        [Test]
        public async Task Create_ShouldAddOrderToDatabase_Success()
        {
            // Arrange
            var user = FakeDataBogus.GenerateRestrauntUser();
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            var order = FakeDataBogus.GenerateOrder();


            // Act
            var result = await _orderRepository.Create(order);

            _dbContext.SaveChanges();

            // Assert
            Assert.IsTrue(result);

        }

        [Test]
        public async Task Create_ShouldAddOrderToDatabase_Failed()
        {
            // Arrange
            var user = FakeDataBogus.GenerateRestrauntUser();
            var order = FakeDataBogus.GenerateOrder();


            // Act
            var result = await _orderRepository.Create(order);

            // Assert
            Assert.IsFalse(result);

        }

        [Test]

        public async Task Delete_ShouldDeleteDishToDatabase_Success()
        {
            // Arrange
            
            Guid Id = Guid.Parse("9eb94f67-1753-4957-a687-14211a1d0cfc");


            // Act
            var result = await _orderRepository.Delete(Id);
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
            var result = await _orderRepository.Delete(Id);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task SelectAllOrders()
        {
            //Arrange
            

            //Act 
            var result = await _orderRepository.Select();

            //Assert
            Assert.AreEqual(_dbContext.Orders.Count(), result.Count());
        }
       

    }
}
