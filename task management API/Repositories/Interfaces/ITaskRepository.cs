using task_management_API.Models;

namespace task_management_API.Repositories.Interfaces
{
	public interface ITaskRepository
	{
		IEnumerable<Tasks> GetAllTasks();
		Tasks GetTaskById(int taskId);
		void AddTask(Tasks task);
		void UpdateTask(Tasks task);
		void DeleteTask(int taskId);
	}
}
