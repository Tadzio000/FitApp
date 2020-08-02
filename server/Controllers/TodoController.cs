using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace TodoApi.Controllers
{
    [Route("users/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;
        public TodoController(TodoContext context)
        {
            _context = context;
            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new AuthenticateModel { Username = "Item1" }); _context.SaveChanges();
            }
        }
        [HttpGet]
        public ActionResult<List<AuthenticateModel>> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<AuthenticateModel> GetById(long id)
        {
            var item = _context.Users.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}