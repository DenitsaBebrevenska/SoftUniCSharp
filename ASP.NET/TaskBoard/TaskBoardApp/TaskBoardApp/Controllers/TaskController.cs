using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Controllers;
public class TaskController : BaseController
{
    private readonly TaskBoardDbContext _context;

    public TaskController(TaskBoardDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        TaskFormViewModel taskModel = new TaskFormViewModel()
        {
            Boards = await GetBoardsAsync()
        };

        return View(taskModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskFormViewModel model)
    {
        if ((await GetBoardsAsync()).All(b => b.Id != model.BoardId))
        {
            ModelState.AddModelError(nameof(model.BoardId), "Board does not exist");
        }

        if (!ModelState.IsValid)
        {
            model.Boards = await GetBoardsAsync();

            return View(model);
        }

        string currentUserId = GetUserId();

        Task task = new Task()
        {
            Title = model.Title,
            Description = model.Description,
            CreatedOn = DateTime.Now,
            BoardId = model.BoardId,
            OwnerId = currentUserId
        };

        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Board");
    }

    public async Task<IActionResult> Details(int id)
    {
        var task = await _context
            .Tasks
            .Include(t => t.Owner)
            .Include(t => t.Board)
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();

        if (task == null)
        {
            return BadRequest();
        }

        var viewModel = new TaskDetailsViewModel()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            CreatedOn = task.CreatedOn?.ToString() ?? "",
            Board = task.Board?.Name ?? "",
            Owner = task.Owner.UserName
        };

        return View(viewModel);
    }

    private async Task<IEnumerable<TaskBoardsViewModel>> GetBoardsAsync()
    {
        return await _context
            .Boards
            .AsNoTracking()
            .Select(b => new TaskBoardsViewModel()
            {
                Id = b.Id,
                Name = b.Name
            })
            .ToListAsync();
    }

    private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);
}
