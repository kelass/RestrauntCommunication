using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restraunt.Core.Dto;
using Restraunt.Core;
using Restraunt.Data;

namespace Restraunt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public OrderController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Select()
        {
            var select = await _unitOfWork.Orders.Select();
            return Ok(select);

        }
        [HttpPost("{Id}")]
        public async Task<ActionResult<IEnumerable<Order>>> SelectForWaiter([FromBody] Guid UserId)
        {
            var select = await _unitOfWork.Orders.SelectOrderUserId(UserId);
            return Ok(select);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Order>> Get(Guid Id)
        {
            var entity = await _unitOfWork.Orders.Get(Id);
            if (entity == null)
            {
                return BadRequest("Order not found");
            }

            var Get = await _unitOfWork.Orders.Get(Id);

            return Ok(Get);

        }



        [HttpPost]
        
        public async Task<ActionResult<List<Order>>> Add([FromBody] OrderDto order)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Orders.Create(order);
                await _unitOfWork.Save();
            }
            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult<List<Order>>> Delete([FromBody] Guid Id)
        {
            var entity = await _unitOfWork.Orders.Get(Id);

            if (entity == null)
                return BadRequest("Id not found");

            await _unitOfWork.Orders.Delete(Id);
            _unitOfWork.Save();
            return Ok("Order delete");

        }


    }
}
