using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SPCS.ViewModel
{
    [Authorize(Roles = "Admin")]
    public class ApplicationUserVM 
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public List<string>? Roles { get; set; }
    }
}
