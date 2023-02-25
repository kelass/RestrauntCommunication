using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using Restraunt.Core.Dto;
using Restraunt.Data;
using Restraunt.Data.Interfaces;

namespace Restraunt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    
    public class DishController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
       
       
        public DishController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> Select()
        {
            var Select = await _unitOfWork.Dishes.Select();
            return Ok(Select);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Dish>> Get(Guid Id)
        {
            var entity = await _unitOfWork.Dishes.Get(Id);
            if (entity == null)
            {
                return BadRequest("Entity not found");
            }
            
                var Get = await _unitOfWork.Dishes.Get(Id);
           
            return Ok(Get);

        }



        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List<Dish>>> Add([FromBody] DishDto dish)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Dishes.Create(dish);
                await _unitOfWork.Save();
            }
            return Ok();
                
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<List<Dish>>> Delete([FromBody] Guid Id)
        {
            var entity = await _unitOfWork.Dishes.Get(Id);

            if (entity == null)
                return BadRequest("Id not found");

           await _unitOfWork.Dishes.Delete(Id);
            _unitOfWork.Save();
            return Ok("Dish delete");

        }


    }
}
