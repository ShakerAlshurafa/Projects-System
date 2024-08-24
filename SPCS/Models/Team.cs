using SPCS.Models.project;
using SPCS.Models.user;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPCS.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;



        public Workgroup? Workgroup { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Supervisor> Supervisors { get; set; } = new List<Supervisor>();
    }
}
