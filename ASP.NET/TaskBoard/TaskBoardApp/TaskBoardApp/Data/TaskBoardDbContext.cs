using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskBoardApp.Data;
public class TaskBoardDbContext : IdentityDbContext
{
	public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
		: base(options)
	{
	}
}
