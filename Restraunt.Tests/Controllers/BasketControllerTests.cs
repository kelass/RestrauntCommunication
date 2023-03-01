using Microsoft.AspNetCore.Mvc;
using Moq;
using Restraunt.Core;
using Restraunt.Core.Interfaces;
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




    public class BasketControllerTests
    {
        private readonly Mock<IBaseRepository<Dish>> _dishRepository;
        private readonly Mock<IUnitOfWorks> _unitOfWork;


        
        


        [Test]
        public void SelectDishesFromBasket()
        {
            //arrange
            var dishes = FakeDataBogus.GetDishes(3);

            var controller = new BasketController();

            //act
            var actionResult = controller.ViewBasket();

            var result = actionResult as OkObjectResult;


            var actual = result.Value as List<Dish>;

            //assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual(dishes, result.Value);
        }


        


    }
}
