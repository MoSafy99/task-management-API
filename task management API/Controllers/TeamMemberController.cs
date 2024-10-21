using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_management_API.Models;
using task_management_API.Repositories.Interfaces;

namespace task_management_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeamMemberController : ControllerBase
	{
		private readonly ITeamMemberRepository _teamMemberRepository;

		public TeamMemberController(ITeamMemberRepository teamMemberRepository)
		{
			_teamMemberRepository = teamMemberRepository;
		}

		
		[HttpGet]
		public IActionResult GetAllMembers()
		{
			var members = _teamMemberRepository.GetAllMembers();
			return Ok(members);
		}

		
		[HttpGet("{id}")]
		public IActionResult GetMemberById(int id)
		{
			var member = _teamMemberRepository.GetMemberById(id);
			if (member == null)
				return NotFound(new { message = $"Member with ID {id} not found." });

			return Ok(member);
		}

		
		[HttpPost]
		public IActionResult AddMember([FromBody] TeamMember member)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			_teamMemberRepository.AddMember(member);
			return CreatedAtAction(nameof(GetMemberById), new { id = member.MemberId }, member);
		}

		
		[HttpPut("{id}")]
		public IActionResult UpdateMember(int id, [FromBody] TeamMember member)
		{
			
			if (id != member.MemberId)
				return BadRequest(new { message = "The Member ID in the URL different , Please ensure they match." });

			// Check if the member exists
			var existingMember = _teamMemberRepository.GetMemberById(id);
			if (existingMember == null)
			{
				return NotFound(new { message = $"Member with ID {id} not found." });
			}

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			_teamMemberRepository.UpdateMember(member);
			return NoContent();
		}

		
		[HttpDelete("{id}")]
		public IActionResult DeleteMember(int id)
		{
			// Check if the member exists
			var member = _teamMemberRepository.GetMemberById(id);
			if (member == null)
			{
				return NotFound(new { message = $"Member with ID {id} not found." });
			}

			_teamMemberRepository.DeleteMember(id);
			return NoContent();
		}
	}

}
