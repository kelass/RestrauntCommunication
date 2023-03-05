using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using Restraunt.Core;
using Restraunt.Core.Dto;
using Restraunt.Data;
using Restraunt.Data.Interfaces;
using Restraunt.Data.Repositories;
using System.Data;
using System.Drawing;

namespace Restraunt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
       

        public TableController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }



        [HttpGet]
        public async Task<ActionResult<List<Table>>> Get()
        {
            return Ok(await _unitOfWork.Tables.Select());

        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<Table>> Get(Guid Id)
        {
            var entity = await _unitOfWork.Tables.Get(Id);
            if (entity == null)
                return BadRequest("Entity not found");

            return Ok(await _unitOfWork.Tables.Get(Id));

        }



        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List<Table>>> AddTable([FromBody] TableDto? table)
        {
            if (ModelState.IsValid)
            {

                table.Link = $"{HttpContext.Request.Scheme}://localhost:45591/Table/Menu/{table.Id.ToString()}";

                await _unitOfWork.Tables.Create(table);
                await _unitOfWork.Save();
                return Ok(table.Link);
            }
            else
            {
                return BadRequest("Problem..");
            }

        }


        [HttpPut]
        [Authorize]

        public async Task<ActionResult<List<Table>>> EditTable([FromBody] EditTableDto table)

        {
            await _unitOfWork.Tables.Edit(table);
            await _unitOfWork.Save();
            return Ok(table);
        }

        [HttpDelete]
        [Authorize]

        public async Task<ActionResult<List<Table>>> DeleteTable([FromBody] Guid Id)

        {
            var entity = await _unitOfWork.Tables.Get(Id);
            if (entity == null)
                return BadRequest("Id not found");

            await _unitOfWork.Tables.Delete(Id);
            _unitOfWork.Save();
            return Ok("Table delete");

        }
        [HttpPatch]
        [Authorize]
        public async Task<ActionResult<List<Table>>> BindUserToTable(BindUserToTableDto model)
        {
            await _unitOfWork.Tables.BindUserToTable(model);
            await _unitOfWork.Save();
            return Ok("User bind to table");
        }


    }
}
