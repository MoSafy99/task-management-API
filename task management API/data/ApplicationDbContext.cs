using Microsoft.EntityFrameworkCore;
using task_management_API.Models;

namespace task_management_API.data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{
		}

		public DbSet<Tasks> Tasks { get; set; }
		public DbSet<TeamMember> TeamMembers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//fluent Api
			modelBuilder.Entity<Tasks>()
		   .HasKey(t => t.TaskId);  

			modelBuilder.Entity<TeamMember>()
				.HasKey(m => m.MemberId);

			modelBuilder.Entity<TeamMember>()
			.HasMany(m => m.Tasks)
			.WithOne(t => t.Member)
			.HasForeignKey(t => t.MemberId);

			modelBuilder.Entity<TeamMember>()
			.Property(m => m.Email)
			.IsRequired()
			.HasMaxLength(255);



		}




	}
}
