using System.ComponentModel.DataAnnotations;

namespace SPCS.ViewModel
{
    public class SupervisorCreateVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Middle name cannot be longer than 50 characters.")]
        public string MiddleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Team ID is required.")]
        public int TeamId { get; set; }
    }
}
