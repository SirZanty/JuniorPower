namespace JuniorPower.Models;

public class StudyDay
{
    public int Id { get; set; }
    public int DayNumber { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Objectives { get; set; } = "";   // JSON array as string
    public string Topics { get; set; } = "";        // JSON array as string
    public string ProjectName { get; set; } = "";
    public string ProjectDescription { get; set; } = "";
    public string ErrorsToProvoke { get; set; } = ""; // JSON array as string
    public string DayGoal { get; set; } = "";
    public string Icon { get; set; } = "";

    public ICollection<StudyTask> Tasks { get; set; } = new List<StudyTask>();
}
