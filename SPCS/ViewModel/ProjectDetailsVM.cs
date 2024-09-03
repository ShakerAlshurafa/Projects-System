using SPCS.Models;
using SPCS.Models.project;

namespace SPCS.ViewModel
{
    public class ProjectDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Overview { get; set; } = null!;
        public string Status { get; set; } = null!;

        //// Try to get data direct from user table so we can do without Studetn, Customer, Supervisor tables
        ///  Not complete yet 
        ///  
        //public string Role { get; set; } = null!;   
        //public ICollection<ApplicationUser>? ProjectStudnet { get; set; } 

        public Workgroup? Workgroup { get; set; }
        public ICollection<ProjectFeatures> Features { get; set; } = new List<ProjectFeatures>();
        public ICollection<ProjectTechnology> Technology { get; set; } = new List<ProjectTechnology>();
        public ICollection<ProjectGoal> Goals { get; set; } = new List<ProjectGoal>();
        public ICollection<ProjectAudience> Audience { get; set; } = new List<ProjectAudience>();

    }
}
