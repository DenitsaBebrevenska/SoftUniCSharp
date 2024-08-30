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

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var task = await _context
            .Tasks
            .AsNoTracking()
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

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var task = await _context
            .Tasks
            .FindAsync(id);

        if (task == null)
        {
            return BadRequest();
        }

        var currentUserId = GetUserId();

        if (currentUserId != task.OwnerId)
        {
            return Unauthorized();
        }

        var model = new TaskFormViewModel()
        {
            Title = task.Title,
            Description = task.Description,
            BoardId = task.BoardId,
            Boards = await GetBoardsAsync()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TaskFormViewModel model, int id)
    {

        var task = await _context
            .Tasks
            .FindAsync(id);

        if (task == null)
        {
            return BadRequest();
        }

        var currentUserId = GetUserId();

        if (currentUserId != task.OwnerId)
        {
            return Unauthorized();
        }

        if ((await GetBoardsAsync()).All(b => b.Id != model.BoardId))
        {
            ModelState.AddModelError(nameof(model.BoardId), "Board does not exist");
        }


        if (!ModelState.IsValid)
        {
            model.Boards = await GetBoardsAsync();
            return View(model);
        }

        task.Title = model.Title;
        task.Description = model.Description;
        task.BoardId = model.BoardId;

        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Board");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _context
            .Tasks
            .FindAsync(id);

        if (task == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();

        if (currentUserId != task.OwnerId)
        {
            return Unauthorized();
        }

        TaskViewModel model = new TaskViewModel()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(TaskViewModel model)
    {
        var task = await _context
            .Tasks
            .FindAsync(model.Id);

        if (task == null)
        {
            return BadRequest();
        }

        var currentUserId = GetUserId();

        if (currentUserId != task.OwnerId)
        {
            return Unauthorized();
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Board");
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
