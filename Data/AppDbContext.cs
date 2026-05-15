using JuniorPower.Models;
using Microsoft.EntityFrameworkCore;

namespace JuniorPower.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<StudyDay> StudyDays => Set<StudyDay>();
    public DbSet<StudyTask> StudyTasks => Set<StudyTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudyTask>()
            .HasOne(t => t.StudyDay)
            .WithMany(d => d.Tasks)
            .HasForeignKey(t => t.StudyDayId);
    }
}
