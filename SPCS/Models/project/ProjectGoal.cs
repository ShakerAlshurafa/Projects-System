namespace SPCS.Models.project
{
    public class ProjectGoal 
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        //public int Priority { get; set; } // e.g., 1 (High), 2 (Medium), 3 (Low)
        //public bool IsCompleted { get; set; } = false;

        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

    }
}
