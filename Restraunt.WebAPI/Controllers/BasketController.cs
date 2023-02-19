using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restraunt.Core;
using Restraunt.Core.Dto;

namespace Restraunt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private static List<Basket> _basket = new List<Basket>();

        [HttpPost]
        public ActionResult AddDishToBasket([FromBody] DishDtoToBasket model)
        {
                var result = new Basket { Id = model.Id, Name = model.Name, Price = model.Price, Quantity = 1 };
                _basket.Add(result);
            
            return Ok(_basket.ToList());
        }
        [HttpDelete]
        public ActionResult RemoveDishFromBasket([FromBody] Guid Id)  
        {
            var item = _basket.FirstOrDefault(d => d.Id == Id);
            if (item != null)
            {
                _basket.Remove(item);
            }
            else
            {
                return BadRequest("Basket dont contains this dish");
            }
            return Ok();
        }

        [HttpGet]
        public ActionResult ViewBasket()
        {
            var dishes = _basket.ToList();
            var totalPrice = _basket.Sum(i => i.Price * i.Quantity);

            var viewModel = new BasketDto
            {
                
                BasketList = dishes,
                Price = totalPrice
            };

            return Ok(viewModel);
        }

        
    }
}
