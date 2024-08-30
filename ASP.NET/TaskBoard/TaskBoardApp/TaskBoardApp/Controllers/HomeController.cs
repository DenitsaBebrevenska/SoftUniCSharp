using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Home;

namespace TaskBoardApp.Controllers;
public class HomeController : Controller
{
    private readonly TaskBoardDbContext _context;

    public HomeController(TaskBoardDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var taskBoards = await _context
            .Boards
            .AsNoTracking()
            .Select(b => b.Name)
            .Distinct()
            .ToListAsync();

        var tasksCount = new List<HomeBoardViewModel>();

        foreach (var taskBoard in taskBoards)
        {
            var tasksOnBoard = _context
                .Tasks
                .AsNoTracking()
                .Count(t => t.Board != null && t.Board.Name == taskBoard);

            tasksCount.Add(new HomeBoardViewModel()
            {
                BoardName = taskBoard,
                TaskCount = tasksOnBoard
            });
        }

        var userTasksCount = -1;

        if (User.Identity.IsAuthenticated)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            userTasksCount = _context
                .Tasks
                .AsNoTracking()
                .Count(t => t.OwnerId == currentUserId);
        }

        var homeModel = new HomeViewModel()
        {
            AllTasksCount = _context.Tasks.Count(),
            BoardsWithTasksCount = tasksCount,
            UserTaskCount = userTasksCount
        };

        return View(homeModel);
    }
}
