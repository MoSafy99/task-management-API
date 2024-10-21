using Microsoft.EntityFrameworkCore;
using task_management_API.data;
using task_management_API.Models;
using task_management_API.Repositories.Interfaces;

namespace task_management_API.Repositories.Implementations
{
	public class TeamMemberRepository : ITeamMemberRepository
	{
		private readonly ApplicationDbContext _context;

		public TeamMemberRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<TeamMember> GetAllMembers()
		{
			return _context.TeamMembers.Include(t => t.Tasks).ToList();
		}

		public TeamMember GetMemberById(int memberId)
		{
			return _context.TeamMembers.Include(t => t.Tasks).FirstOrDefault(m => m.MemberId == memberId);
		}

		public void AddMember(TeamMember member)
		{
			_context.TeamMembers.Add(member);
			_context.SaveChanges();
		}

		public void UpdateMember(TeamMember member)
		{
			_context.TeamMembers.Update(member);
			_context.SaveChanges();
		}

		public void DeleteMember(int memberId)
		{
			var member = _context.TeamMembers.Find(memberId);
			if (member != null)
			{
				_context.TeamMembers.Remove(member);
				_context.SaveChanges();
			}
		}
	}

}
