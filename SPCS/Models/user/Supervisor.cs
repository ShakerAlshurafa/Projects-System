namespace SPCS.Models.user
{
    public class Supervisor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
