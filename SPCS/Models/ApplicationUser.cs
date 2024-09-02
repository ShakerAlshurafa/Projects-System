using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SPCS.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string Address { get; set; }
        public bool IsDeleted { get; set; } // soft delete
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
