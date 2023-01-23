﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using Restraunt.Core;
using Restraunt.Data;
using Restraunt.Data.Interfaces;
using System.Data;
using System.Drawing;

namespace Restraunt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableRepository _tableRepository;
        
       
        //DI
        public TableController(ITableRepository tableRepository)
        {
            _tableRepository= tableRepository;
           
        }

        

        [HttpGet]
        public async Task<ActionResult<List<Table>>> Get()
        {
           

            return Ok(await _tableRepository.Select());

        } 
       

        [HttpGet("{Id}")]
        public async Task<ActionResult<Table>> Get(Guid Id)
        {
           

           

            return Ok(await _tableRepository.Get(Id));

        }  


        
         [HttpPost]
        public async Task<ActionResult<List<Table>>> AddTable(Table table)
        {
            if (ModelState.IsValid)
            {
                

           table.Link = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Table/{table.Id.ToString()}";
           await _tableRepository.Create(table);

                QRCodeHelper.GetQRCode(table.Link,20,Color.Black,Color.White,QRCodeGenerator.ECCLevel.M);
               
            }
            return Ok(await _tableRepository.Select());

        }


        //[HttpPut]

        //public async Task<ActionResult<List<Table>>> EditTable(Table Request)
        //{
        //    var Table = Tables.Find(t => t.Id == Request.Id);

        //    if (Table == null)
        //        return BadRequest("Table not found");

        //    Table.Name = Request.Name;

        //    return Ok(Tables);

        //}

        [HttpDelete]
        public async Task<ActionResult<List<Table>>> DeleteTable(Guid Id)
        {
          await _tableRepository.Delete(Id);
            return Ok(await _tableRepository.Select());

        }






    }
}