namespace SPCS.Models.user
{
    public class Supervisor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
