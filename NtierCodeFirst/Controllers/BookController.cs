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
    public class BookController : Controller
    {
        BookBusines bookBusines = new BookBusines();
        [HttpGet("GetBook")]
        public IActionResult GetAll()
        {
            return Ok(bookBusines.GetAll());
        }
        [HttpGet("GetWith")]
        public IActionResult GetAllWithCondiction(string name)
        {
            return Ok(bookBusines.GetAllWithCondiction(name));
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(bookBusines.Get(id));
        }
        [HttpPost("AddBook")]
        public IActionResult Add(Book book)
        {
            return Ok(bookBusines.Add(book));
        }
        [HttpPut("UpdateBook")]
        public IActionResult Update(Book book)
        {
            return Ok(bookBusines.Update(book));
        }
        [HttpDelete("DeleteBook")]
        public IActionResult Delete(int id)
        {
            return Ok(bookBusines.Delete(id));
        }
       

    }
}
