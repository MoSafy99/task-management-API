using System.ComponentModel.DataAnnotations;

namespace task_management_API.Models
{
	public class TeamMember
	{
		[Key]
		public int MemberId { get; set; }

		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = "Invalid email format")]
		public string Email { get; set; }

		// realation one to many 
		public ICollection<Tasks> Tasks { get; set; }
	}
}