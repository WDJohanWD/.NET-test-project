using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Services;
using Test.Data;
using Test.Models;

namespace test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("/test")]
        public ActionResult<string> Test()
        {
            return "API is working!";
        }

        [HttpGet("/getAll")]
        public async Task<List<TaskItem>> getAll()
        {
            return await _taskService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetOne(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null) return NotFound();
            return task;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> Create(TaskItem task)
        {
            var created = await _taskService.CreateTask(task);
            return CreatedAtAction(nameof(GetOne), new { id = created.Id }, created);
        }


        /*
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItem updatedTask)
        {
            if (id != updatedTask.Id) return BadRequest();

            _context.Entry(updatedTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }*/
    }
}
