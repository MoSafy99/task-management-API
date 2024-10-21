using task_management_API.data;
using task_management_API.Models;
using task_management_API.Repositories.Interfaces;

namespace task_management_API.Repositories.Implementations
{
	public class TaskRepository : ITaskRepository
	{
		private readonly ApplicationDbContext _context;

		public TaskRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Tasks> GetAllTasks()
		{
			return _context.Tasks.ToList();
		}

		public Tasks GetTaskById(int taskId)
		{
			return _context.Tasks.Find(taskId);
		}

		public void AddTask(Tasks task)
		{
			_context.Tasks.Add(task);
			_context.SaveChanges();
		}

		public void UpdateTask(Tasks task)
		{
			_context.Tasks.Update(task);
			_context.SaveChanges();
		}

		public void DeleteTask(int taskId)
		{
			var task = _context.Tasks.Find(taskId);
			if (task != null)
			{
				_context.Tasks.Remove(task);
				_context.SaveChanges();
			}
		}

	}
}
