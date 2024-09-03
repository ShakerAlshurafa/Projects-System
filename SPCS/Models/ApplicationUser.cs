using Microsoft.AspNetCore.Identity;
using SPCS.Models.project;
using System.ComponentModel.DataAnnotations;

namespace SPCS.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string Address { get; set; } = null!;
        public bool IsDeleted { get; set; } // soft delete
        // To check if user participated in project (insted we can do the check using project id)
        //public bool IsParticipatedInProject { get; set; } = false; 
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        public ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();

    }
}
