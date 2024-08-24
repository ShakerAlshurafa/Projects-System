namespace SPCS.Models.user
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;


        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
