using SPCS.Models.project;
using SPCS.Models.user;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPCS.Models
{
    public class Workgroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int ProjectId { get; set; }
        public int TeamId { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }
        [ForeignKey("TeamId")]
        public Team? Team { get; set; } 
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}
