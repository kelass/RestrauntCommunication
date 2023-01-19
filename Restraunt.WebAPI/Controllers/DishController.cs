using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using Restraunt.Data;
using Restraunt.Data.Interfaces;
namespace Restraunt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class DishController : ControllerBase
    {
        private readonly IDishRepository _dishRepository;
       
       
        public DishController(IDishRepository dishRepository)
        {
          _dishRepository= dishRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dish>>> Select()
        {
            var Select =  await _dishRepository.Select();
            return Ok(Select);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Dish>> Get(Guid Id)
        {
            var Get = await _dishRepository.Get(Id);
            return Ok(Get);

        }



        [HttpPost]
        public async Task<ActionResult<List<Dish>>> Add(Dish dish)
        {
            var Add = await _dishRepository.Create(dish);

            return Ok(await _dishRepository.Select());

        }

        [HttpDelete]
        public async Task<ActionResult<List<Dish>>> Delete(Guid Id)
        {
            var entity = await _dishRepository.Get(Id);

            if (entity == null)
                return BadRequest("Table not found");

           await _dishRepository.Delete(Id);
            return Ok(await _dishRepository.Select());

        }


    }
}
