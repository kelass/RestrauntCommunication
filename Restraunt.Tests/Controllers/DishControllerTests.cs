using Microsoft.AspNetCore.Mvc;
using Moq;
using Restraunt.Core;
using Restraunt.Core.Interfaces;
using Restraunt.Data;
using Restraunt.Data.Interfaces;
using Restraunt.Tests.TestHelper;
using Restraunt.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restraunt.Tests.Controllers
{
    public class DishControllerTests
    {
        private readonly Mock<IDishRepository> _dishRepository;
        private readonly Mock<UnitOfWork> _unitOfWorks;

        public DishControllerTests()
        {
            _dishRepository= new Mock<IDishRepository>();
            _unitOfWorks= new Mock<UnitOfWork>();
        }

        [Test]
        public void SelectDish_Success()
        {
            //arrange
            IEnumerable<Dish> dishes = FakeDataBogus.GetDishes(5);
            _dishRepository.Setup(x => x.Select()).Returns(Task.FromResult(dishes));
            var controller = new DishController(_unitOfWorks.Object);

            //act
            var actionResult = controller.Select();
            var result = Task.FromResult(actionResult);
            var actual = result.Result as IEnumerable<Dish>;


            //assert
            Assert.AreEqual(FakeDataBogus.GetDishes(5), actual.ToList());
        }
    }
}
