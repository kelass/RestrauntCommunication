using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restraunt.Core;
using Restraunt.Data;

namespace Restraunt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        private static List<Table> Tables = new List<Table>
        {
         new Table {Id = Guid.Parse("0ce6cde0-813c-441d-bdbd-05eaf34d6a7c"), Name="Table Test"}

        };
        //DI
        public TableController(ApplicationDbContext db)
        {
            _db = db;



            var Tables = _db.Tables.AsNoTracking().ToList();
        }

        

        [HttpGet]
        public async Task<ActionResult<List<Table>>> Get()
        {
           

            return Ok(Tables);

        } 
       

        [HttpGet("{Id}")]
        public async Task<ActionResult<Table>> Get(Guid Id)
        {
            var Table = Tables.Find(t => t.Id == Id);

            if (Table == null)
                return BadRequest("Table not found");

            return Ok(Table);

        }  


        
         [HttpPost]
        public async Task<ActionResult<List<Table>>> AddTable(Table table)
        {
            Tables.Add(table);

            return Ok(Tables);

        }


        [HttpPut]

        public async Task<ActionResult<List<Table>>> EditTable(Table Request)
        {
            var Table = Tables.Find(t => t.Id == Request.Id);

            if (Table == null)
                return BadRequest("Table not found");

            Table.Name = Request.Name;

            return Ok(Tables);

        }

        [HttpDelete]
        public async Task<ActionResult<List<Table>>> DeleteTable(Guid Id)
        {
            var Table = Tables.Find(t => t.Id == Id);

            if (Table == null)
                return BadRequest("Table not found");

            Tables.Remove(Table);
            return Ok(Tables);

        }






    }
}
