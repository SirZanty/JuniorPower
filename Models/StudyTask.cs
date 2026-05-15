namespace JuniorPower.Models;

public class StudyTask
{
    public int Id { get; set; }
    public int StudyDayId { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public TaskCategory Category { get; set; }
    public int OrderIndex { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }

    public StudyDay StudyDay { get; set; } = null!;
}

public enum TaskCategory
{
    Theory,
    Practice,
    Project,
    Exercise,
    Reading
}
