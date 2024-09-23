using System.ComponentModel.DataAnnotations;

namespace SPCS.ViewModel
{
    public class StudentVM
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public IEnumerable<string> WorkgroupNames { get; set; } = new List<string>();
    }
}
