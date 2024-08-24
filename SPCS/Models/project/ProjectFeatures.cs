namespace SPCS.Models.project
{
    public class ProjectFeatures
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
    }
}
