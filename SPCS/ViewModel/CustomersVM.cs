namespace SPCS.ViewModel
{
    public class CustomersVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public IEnumerable<string> WorkgroupNames { get; set; } = Enumerable.Empty<string>();
    }
}
