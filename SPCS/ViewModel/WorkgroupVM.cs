namespace SPCS.ViewModel
{
    public class WorkgroupVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CustomerId { get; set; }
        public int ProjectId { get; set; }
        public int TeamId { get; set; }
    }
}
