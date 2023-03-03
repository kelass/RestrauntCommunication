using Microsoft.EntityFrameworkCore;
using Moq;
using Restraunt.Core;
using Restraunt.Core.Interfaces;
using Restraunt.Data;
using Restraunt.Data.Interfaces;
using Restraunt.Data.Repositories;
using Restraunt.Tests.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Tests
{
    public class UnitOfWorkTests
    {
        private readonly Mock<DishRepository> _dishRepository;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UnitOfWorkTests()
        {
            _dishRepository= new Mock<DishRepository>();
            _unitOfWork= new Mock<UnitOfWork>();
        }

        //[Test]
        //public void GetAllDishes_ListOfDishes()
        //{
        //    //Arrange
        //    var dishes = FakeDataBogus.GetDishes(3);

        //    _dishRepository.Setup(x=>x.Select()).Returns(dishes);
        //    _unitOfWork.Setup(x=>x.Dish)

        //    //Act

        //    //Assert
        //}
    }
}
