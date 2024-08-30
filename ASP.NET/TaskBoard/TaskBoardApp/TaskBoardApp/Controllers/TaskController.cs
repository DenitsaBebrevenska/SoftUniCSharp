using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Controllers;

/// <summary>
/// Task controller
/// </summary>
public class TaskController : BaseController
{
    /// <summary>
    /// Db context field
    /// </summary>
    private readonly TaskBoardDbContext _context;

    /// <summary>
    /// DI from constructor for Db context
    /// </summary>
    /// <param name="context"></param>
    public TaskController(TaskBoardDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Returns to the view the task model for the form fill in for task creation.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        TaskFormViewModel taskModel = new TaskFormViewModel()
        {
            Boards = await GetBoardsAsync()
        };

        return View(taskModel);
    }

    /// <summary>
    /// Validates model and if the model is valid and task exists in DB , adds the new task in the DB and redirects to Board/Index.
    /// If the model is invalid or the task does not exist in DB, returns the task model to the view again.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Validates if the provided id is valid and if it is returns to the view the task model.
    /// If the id of the task is invalid, returns bad request.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Validates if the provided id is valid and if the current user is the owner of the task and then returns
    /// to the view the task model for editing.
    /// If the id is invalid, returns bad request.
    /// If the user is not the owner, returns Unauthorized
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Validates task if task exist, if current user is the task`s owner, if the task model is valid
    /// and if board id is valid then edits the task then redirects to Board/Index
    /// If the task does not exist, returns bad request.
    /// If the user is not the task`s owner, returns unauthorized.
    /// If the model is invalid, returns the model to the view.
    /// If the board id is invalid, adds model error.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="id"></param>
    /// <returns></returns>
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


    /// <summary>
    /// Validates task existence, checks if the current user is the task`s owner
    /// and then returns a model to the view.
    /// If the task does not exist, returns bad request.
    /// If the user is not the task`s owner, returns unauthorized.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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


    /// <summary>
    /// Validates task existence, checks if the current user is the task`s owner
    /// and then removes the task from the DB and redirects to Board/Index.
    /// If the task does not exist, returns bad request.
    /// If the user is not the task`s owner, returns unauthorized.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
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

    /// <summary>
    /// The method returns a collection of all TaskBoardsViewModel-s
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Returns the user`s identifier
    /// </summary>
    /// <returns></returns>
    private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);
}
