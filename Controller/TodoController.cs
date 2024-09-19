using Microsoft.AspNetCore.Authorization ;
using Microsoft.AspNetCore.Identity ;
using Microsoft.AspNetCore.Mvc ;
using Microsoft.EntityFrameworkCore ;

using TodoApi.Models ;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // This attribute is required authentication for all action in this controller
    public class TodoController : ControllerBase
    {
        ApplicationDbContext _context ;

     
        public TodoController(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        //GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetTodos()
        {
            return await _context.Todo.ToListAsync() ;
        }

        //get product {id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoModel>> GetTodo
        (
            Guid id
        )
        {
            var todo = await _context.Todo.FindAsync(id) ;
            if ( null == todo )
            {
                return NotFound() ;
            }

            return todo ;
        }    
                // PUT: api/todo/{id} - Update a todo item
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(Guid id, TodoModel todoModel)
        {
            if (id != todoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        
        // DELETE: api/todo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            var todo = await _context.Todo.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/todo - Create a new todo item
        [HttpPost]
        public async Task<ActionResult<TodoModel>> CreateTodo(TodoModel todoModel)
        {
            // Validate the incoming model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the new todo item to the database
            _context.Todo.Add(todoModel);
            await _context.SaveChangesAsync();

            // Return the newly created item with its generated ID
            return CreatedAtAction(nameof(GetTodo), new { id = todoModel.Id }, todoModel);
        }


        // Helper method to check if a Todo exists by ID
        private bool TodoExists(Guid id)
        {
            return _context.Todo.Any(e => e.Id == id);
        }    
    }
}