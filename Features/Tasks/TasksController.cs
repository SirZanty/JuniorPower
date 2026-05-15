using JuniorPower.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuniorPower.Features.Tasks;

public class TasksController : Controller
{
    private readonly AppDbContext _db;

    public TasksController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index(int? day)
    {
        var query = _db.StudyTasks
            .Include(t => t.StudyDay)
            .AsQueryable();

        if (day.HasValue)
            query = query.Where(t => t.StudyDay.DayNumber == day.Value);

        var tasks = await query
            .OrderBy(t => t.StudyDay.DayNumber)
            .ThenBy(t => t.OrderIndex)
            .ToListAsync();

        ViewBag.FilterDay = day;
        return View(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Toggle(int id)
    {
        var task = await _db.StudyTasks.FindAsync(id);
        if (task == null) return NotFound();

        task.IsCompleted = !task.IsCompleted;
        task.CompletedAt = task.IsCompleted ? DateTime.UtcNow : null;

        await _db.SaveChangesAsync();

        return Json(new { isCompleted = task.IsCompleted });
    }

    [HttpPost]
    public async Task<IActionResult> ResetDay(int dayNumber)
    {
        var tasks = await _db.StudyTasks
            .Include(t => t.StudyDay)
            .Where(t => t.StudyDay.DayNumber == dayNumber)
            .ToListAsync();

        foreach (var task in tasks)
        {
            task.IsCompleted = false;
            task.CompletedAt = null;
        }

        await _db.SaveChangesAsync();
        return RedirectToAction("Index", new { day = dayNumber });
    }
}
