
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using simpleWebApi.Data;
using simpleWebApi.Models;

namespace simpleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

                //get Database Item and return to view
        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            //ViewBag.Error = TempData["ModelState"];
            //var items =_dbContext.TodoItems.ToList();
            List<TodoItem> items = _context.TodoItems.ToList();
            return Ok(items); 
        
        }
        
        
       
        [HttpPost]
        //take input from user and post to database
        public IActionResult Add(TodoItem model) 
        {
            if (model == null) throw new ArgumentNullException(message: "Todo Cannot be null", null); 

            _context.TodoItems.Add(model);
            _context.SaveChanges();
            return CreatedAtAction("Add", model);
        }
        
        [HttpGet("{ID}")]
        public IActionResult SingleItem(int ID) 
        {
            //if (ID == null) throw new ArgumentNullException(message: "ID Cannot be null", null);
            if (ID <= 0) return NotFound();

            var item = _context.TodoItems.FirstOrDefault(x => x.ID == ID);
            //if (item == null) return RedirectToAction("Index");
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item); 
    }

        //take Edited input from user and Update to database

        [HttpPut("{ID}")]
        public IActionResult EditItem(int ID, [FromBody] TodoItem model) 
        {
            if (ID <= 0) return NotFound();
            if (model == null) throw new ArgumentNullException(message: "Todo Cannot be null", null);


            var item = _context.TodoItems.FirstOrDefault(x => x.ID == ID);
            if (item == null)
            {
                return NotFound();
            }

            item.Name = model.Name;
            item.Description = model.Description;
            item.DueDate = model.DueDate;

            _context.TodoItems.Update(item);
            _context.SaveChanges();
            return Ok(item);

        }

        [HttpDelete("{ID}")]
         //Delete Data from the Database
        public IActionResult DeleteItem(int ID) 
        {
            if (ID <= 0) return NotFound();
            

            var item = _context.TodoItems.FirstOrDefault(x => x.ID == ID);
            if (item == null)
            {
                return NotFound();
            } 

            _context.TodoItems.Remove(item);
            _context.SaveChanges();
            return Ok(item);
        }
    }
}