using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Board;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Controllers;

/// <summary>
/// Board controller
/// </summary>
public class BoardController : BaseController
{
    /// <summary>
    /// Db context field
    /// </summary>
    private readonly TaskBoardDbContext _context;

    /// <summary>
    /// DI from constructor for Db context
    /// </summary>
    /// <param name="context"></param>
    public BoardController(TaskBoardDbContext context)
    {
        _context = context;
    }


    /// <summary>
    /// The index method. Displays all boards and the tasks on them with details
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var boards = await _context.Boards
            .AsNoTracking()
            .Select(b => new BoardViewModel()
            {
                Id = b.Id,
                Name = b.Name,
                Tasks = b.Tasks
                    .Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    })
            })
            .ToListAsync();

        return View(boards);
    }
}
