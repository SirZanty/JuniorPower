using JuniorPower.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuniorPower.Features.StudyPlan;

public class StudyPlanController : Controller
{
    private readonly AppDbContext _db;

    public StudyPlanController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var days = await _db.StudyDays
            .Include(d => d.Tasks)
            .OrderBy(d => d.DayNumber)
            .ToListAsync();

        return View(days);
    }

    public async Task<IActionResult> Day(int id)
    {
        var day = await _db.StudyDays
            .Include(d => d.Tasks.OrderBy(t => t.OrderIndex))
            .FirstOrDefaultAsync(d => d.DayNumber == id);

        if (day == null) return NotFound();

        return View(day);
    }
}
