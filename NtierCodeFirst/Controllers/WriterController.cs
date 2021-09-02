using Business;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NtierCodeFirst.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : Controller
    {
        WriterBusines writerBus = new WriterBusines();
        [HttpGet("Get")]
        public IActionResult GetAll()
        {
            return Ok(writerBus.GetAll());
        }
        [HttpGet("GetWith")]
        public IActionResult GetAllWithCondiction(string name)
        {
            return Ok(writerBus.GetAllWithCondiction(name));
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(writerBus.Get(id));
        }
        [HttpPost("AddWriter")]
        public IActionResult Add(Writer writer)
        {
            return Ok(writerBus.Add(writer));
        }
        [HttpPut("UpdateWriter")]
        public IActionResult Update(Writer writer)
        {
            return Ok(writerBus.Update(writer));
        }
        [HttpDelete("DeleteWriter")]
        public IActionResult Delete(int id)
        {
            return Ok(writerBus.Delete(id));
        }
    }
}
