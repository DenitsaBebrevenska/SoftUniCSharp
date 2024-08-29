using Microsoft.AspNetCore.Identity;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;
namespace TaskBoardApp.Data.SeedData;

public static class SeedHelper
{
    private const string MockUserEmail = "test@softuni.bg";
    private static IdentityUser _testUser;
    private static Board _openBoard;
    private static Board _inProgressBoard;
    private static Board _doneBoard;
    public static IEnumerable<Task> SeedTasks()
    {
        Task[] tasks = new[]
        {
            new Task()
            {
                Id = 1,
                Title = "Write hello world",
                Description = "Write hello world in javascript",
                CreatedOn = DateTime.Now.AddDays(-265),
                OwnerId = _testUser.Id,
                BoardId = _openBoard.Id
            },
            new Task()
            {
                Id = 2,
                Title = "Read about MVC",
                Description = "Search more info on MVC and watch some youtube tutorials",
                CreatedOn = DateTime.Now.AddDays(-30),
                OwnerId = _testUser.Id,
                BoardId = _openBoard.Id
            },
            new Task()
            {
                Id = 3,
                Title = "Work with AJAX",
                Description = "Make my AJAX exercises and solve some JS exams",
                CreatedOn = DateTime.Now.AddDays(-10),
                OwnerId = _testUser.Id,
                BoardId = _inProgressBoard.Id
            },
            new Task()
            {
                Id = 4,
                Title = "Play around with Angular",
                Description = "Watch Udemy Angular course and do the tasks",
                CreatedOn = DateTime.Now.AddDays(-60),
                OwnerId = _testUser.Id,
                BoardId = _doneBoard.Id
            }
        };
        return tasks;
    }

    public static IdentityUser SeedUser()
    {
        _testUser = new IdentityUser()
        {
            UserName = MockUserEmail,
            NormalizedUserName = MockUserEmail.ToUpper()
        };

        var hasher = new PasswordHasher<IdentityUser>();
        _testUser.PasswordHash = hasher.HashPassword(_testUser, "softuni");

        return _testUser;
    }

    public static IEnumerable<Board> SeedBoards()
    {
        var boards = new Board[]
        {
            _openBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            },
            _inProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            },
            _doneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            }
        };

        return boards;
    }

}
