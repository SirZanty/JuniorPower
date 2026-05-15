using JuniorPower.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuniorPower.Features.Dashboard;

public class DashboardController : Controller
{
    private readonly AppDbContext _db;

    public DashboardController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var allTasks = await _db.StudyTasks.ToListAsync();
        var completedTasks = allTasks.Count(t => t.IsCompleted);
        var totalTasks = allTasks.Count;
        var progressPercent = totalTasks > 0 ? (int)((double)completedTasks / totalTasks * 100) : 0;

        var tasksByDay = await _db.StudyTasks
            .Include(t => t.StudyDay)
            .GroupBy(t => t.StudyDay.DayNumber)
            .Select(g => new DayProgressItem
            {
                DayNumber = g.Key,
                Title = g.First().StudyDay.Title,
                Icon = g.First().StudyDay.Icon,
                Total = g.Count(),
                Completed = g.Count(t => t.IsCompleted)
            })
            .OrderBy(d => d.DayNumber)
            .ToListAsync();

        var vm = new DashboardViewModel
        {
            TotalTasks = totalTasks,
            CompletedTasks = completedTasks,
            ProgressPercent = progressPercent,
            DaysProgress = tasksByDay,
            TotalDays = 7,
            DaysCompleted = tasksByDay.Count(d => d.Completed == d.Total && d.Total > 0)
        };

        return View(vm);
    }
}

public class DashboardViewModel
{
    public int TotalTasks { get; set; }
    public int CompletedTasks { get; set; }
    public int ProgressPercent { get; set; }
    public int TotalDays { get; set; }
    public int DaysCompleted { get; set; }
    public List<DayProgressItem> DaysProgress { get; set; } = new();
}

public class DayProgressItem
{
    public int DayNumber { get; set; }
    public string Title { get; set; } = "";
    public string Icon { get; set; } = "";
    public int Total { get; set; }
    public int Completed { get; set; }
    public int Percent => Total > 0 ? (int)((double)Completed / Total * 100) : 0;
}
