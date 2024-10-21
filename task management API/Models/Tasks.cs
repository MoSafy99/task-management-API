using System.ComponentModel.DataAnnotations;

namespace task_management_API.Models
{
	public class Tasks
	{
		[Key]
		public int TaskId { get; set; }

		[Required(ErrorMessage = "Task name is required")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Task description is required")]
		public string Description { get; set; }

		public string Status { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		// foreign key
		public int MemberId { get; set; }
		public TeamMember Member { get; set; }
	}

}
