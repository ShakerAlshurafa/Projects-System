using SPCS.Models.project;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPCS.Models.user
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;


        public Workgroup? Workgroup { get; set; }

    }
}
