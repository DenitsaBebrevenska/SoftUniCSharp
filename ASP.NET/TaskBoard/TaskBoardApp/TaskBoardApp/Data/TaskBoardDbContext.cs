using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;
using TaskBoardApp.Data.SeedData;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data;
public class TaskBoardDbContext : IdentityDbContext
{
    public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Task>()
            .HasOne(t => t.Board)
            .WithMany(b => b.Tasks)
            .HasForeignKey(t => t.BoardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<IdentityUser>()
            .HasData(SeedHelper.SeedUser());
        builder.Entity<Board>()
            .HasData(SeedHelper.SeedBoards());
        builder.Entity<Task>()
            .HasData(SeedHelper.SeedTasks());


        base.OnModelCreating(builder);
    }

    public DbSet<Task> Tasks { get; set; }

    public DbSet<Board> Boards { get; set; }
}
