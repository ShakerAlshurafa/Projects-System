using SPCS.Models.project;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPCS.Models.user
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public Workgroup? Workgroup { get; set; }

    }
}
