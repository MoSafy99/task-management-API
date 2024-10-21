using task_management_API.Models;

namespace task_management_API.Repositories.Interfaces
{
	public interface ITeamMemberRepository
	{
		IEnumerable<TeamMember> GetAllMembers();
		TeamMember GetMemberById(int memberId);
		void AddMember(TeamMember member);
		void UpdateMember(TeamMember member);
		void DeleteMember(int memberId);
	}
}
