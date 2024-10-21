using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_management_API.Models;
using task_management_API.Repositories.Interfaces;

namespace task_management_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskController : ControllerBase
	{
		private readonly ITaskRepository _taskRepository;

		public TaskController(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		
		[HttpGet]
		public IActionResult GetAllTasks()
		{
			var tasks = _taskRepository.GetAllTasks();
			return Ok(tasks);
		}

		[HttpGet("{id}")]
		public IActionResult GetTaskById(int id)
		{
			var task = _taskRepository.GetTaskById(id);
			if (task == null)
			{
				return NotFound(new { message = $"Task with ID {id} not found." });
			}
			return Ok(task);
		}

		
		[HttpPost]
		public IActionResult AddTask([FromBody] Tasks task)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			_taskRepository.AddTask(task);
			return CreatedAtAction(nameof(GetTaskById), new { id = task.TaskId }, task);
		}

		
		[HttpPut("{id}")]
		public IActionResult UpdateTask(int id, [FromBody] Tasks task)
		{
			if (id != task.TaskId)
				return BadRequest(new { message = "The Member ID in the URL different , Please ensure they match." });

			var existingTask = _taskRepository.GetTaskById(id);
			if (existingTask == null)
			{
				return NotFound(new { message = $"Task with ID {id} not found." });
			}

			_taskRepository.UpdateTask(task);
			return NoContent();
		}

		
		[HttpDelete("{id}")]
		public IActionResult DeleteTask(int id)
		{
			var task = _taskRepository.GetTaskById(id);
			if (task == null)
			{
				return NotFound(new { message = $"Task with ID {id} not found." });
			}

			_taskRepository.DeleteTask(id);
			return NoContent();
		}
	}

}
