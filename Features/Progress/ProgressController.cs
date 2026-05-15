using JuniorPower.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuniorPower.Features.Progress;

public class ProgressController : Controller
{
    private readonly AppDbContext _db;

    public ProgressController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var days = await _db.StudyDays
            .Include(d => d.Tasks)
            .OrderBy(d => d.DayNumber)
            .ToListAsync();

        var vm = days.Select(d => new DayProgressViewModel
        {
            DayNumber = d.DayNumber,
            Title = d.Title,
            Icon = d.Icon,
            TotalTasks = d.Tasks.Count,
            CompletedTasks = d.Tasks.Count(t => t.IsCompleted),
            LastCompletedAt = d.Tasks.Where(t => t.IsCompleted).Max(t => (DateTime?)t.CompletedAt)
        }).ToList();

        ViewBag.TotalCompleted = vm.Sum(d => d.CompletedTasks);
        ViewBag.TotalTasks = vm.Sum(d => d.TotalTasks);

        return View(vm);
    }

    [HttpGet]
    public async Task<IActionResult> Stats()
    {
        var allTasks = await _db.StudyTasks.Include(t => t.StudyDay).ToListAsync();

        var stats = new
        {
            total = allTasks.Count,
            completed = allTasks.Count(t => t.IsCompleted),
            byCategory = allTasks
                .GroupBy(t => t.Category.ToString())
                .Select(g => new { category = g.Key, total = g.Count(), completed = g.Count(t => t.IsCompleted) })
                .ToList(),
            byDay = allTasks
                .GroupBy(t => t.StudyDay.DayNumber)
                .OrderBy(g => g.Key)
                .Select(g => new { day = g.Key, total = g.Count(), completed = g.Count(t => t.IsCompleted) })
                .ToList()
        };

        return Json(stats);
    }
}

public class DayProgressViewModel
{
    public int DayNumber { get; set; }
    public string Title { get; set; } = "";
    public string Icon { get; set; } = "";
    public int TotalTasks { get; set; }
    public int CompletedTasks { get; set; }
    public DateTime? LastCompletedAt { get; set; }
    public int Percent => TotalTasks > 0 ? (int)((double)CompletedTasks / TotalTasks * 100) : 0;
    public bool IsComplete => CompletedTasks == TotalTasks && TotalTasks > 0;
}
