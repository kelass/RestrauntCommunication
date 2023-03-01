using Bogus;
using Restraunt.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restraunt.Tests.TestHelper
{
    public class FakeDataBogus
    {
        private static List<Dish> _dishes;

        public static List<Dish> GetDishes(int number)
        {
            if(_dishes == null)
            {
                _dishes= new Faker<Dish>()
                    .RuleFor(dish => dish.Price, faker=>faker.IndexFaker+1)
                    .RuleFor(dish=> dish.Name, faker=> faker.Name.FirstName())
                    .RuleFor(dish=>dish.Name, faker=>faker.Name.LastName())
                    .RuleFor(Dish=>Dish.Id, faker=> Guid.NewGuid())
                    .Generate(number);
            }
            return _dishes;
        }
    }
}
