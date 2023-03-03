using Bogus;
using Restraunt.Core;
using Restraunt.Core.Dto;
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
                    .RuleFor(dish=>dish.Description, faker=>faker.Name.LastName())
                    .RuleFor(Dish=>Dish.Id, faker=> Guid.NewGuid())
                    .Generate(number);
            }
            return _dishes;
        }

        public static Dish GenerateOneDish()
        {
            var dish = new Faker<Dish>()
                .RuleFor(Dish => Dish.Id, faker => Guid.NewGuid())
                .RuleFor(Dish => Dish.Name, faker => faker.Name.FirstName())
                .RuleFor(Dish => Dish.Price, faker => faker.IndexFaker + 1)
                .RuleFor(Dish => Dish.Description, faker => faker.Lorem.ToString())
                .Generate();

            return dish;
        }

        public static TableDto GenerateOneTable()
        {
            var table = new Faker<TableDto>()
                .RuleFor(Table => Table.Id, faker => Guid.Parse("d11c14e0-323e-4176-b269-fd799ba4da6a"))
                .RuleFor(Table => Table.Name, faker => faker.Name.FirstName())
                .RuleFor(Table => Table.User, faker => null)
                .RuleFor(Table => Table.Link, faker => "LinkTest")
                .Generate();

            return table;
        }

        public static EditTableDto EditOneTable()
        {
            var table = new Faker<EditTableDto>()
                .RuleFor(Table => Table.Id, faker => Guid.Parse("d11c14e0-323e-4176-b269-fd799ba4da6b"))
                .RuleFor(Table => Table.Name, faker => faker.Name.FirstName())
                
                .Generate();

            return table;
        }

        public static TableDto GenerateOneTableForTheEdit()
        {
            var table = new Faker<TableDto>()
                .RuleFor(Table => Table.Id, faker => Guid.Parse("d11c14e0-323e-4176-b269-fd799ba4da6b"))
                .RuleFor(Table => Table.Name, faker => faker.Name.FirstName())
                .RuleFor(Table => Table.User, faker => null)
                .RuleFor(Table => Table.Link, faker => "LinkTest")
                .Generate();

            return table;
        }
        public static User GenerateRestrauntUser()
        {
            var user = new Faker<User>()
                .RuleFor(User => User.Id, faker => Guid.Parse("9ef94f67-1753-4957-a687-14211a1d0cfc"))
                .RuleFor(User => User.UserName, faker => faker.Name.FirstName())
                .RuleFor(User => User.Email, faker => faker.Person.Email)
                .RuleFor(User => User.UserName, faker => faker.Name.FirstName().ToUpper())
                .Generate();

            return user;
        }
    }
}
