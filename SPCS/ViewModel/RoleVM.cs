using Microsoft.AspNetCore.Authorization;

namespace SPCS.ViewModel
{
    [Authorize(Roles = "Admin")]
    public class RoleVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
