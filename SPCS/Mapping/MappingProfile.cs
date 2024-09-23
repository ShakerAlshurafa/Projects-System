using AutoMapper;
using SPCS.Models;
using SPCS.Models.project;
using SPCS.Models.user;
using SPCS.ViewModel;

namespace SPCS.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectVM>().ReverseMap();
            CreateMap<Project, ProjectDetailsVM>().ReverseMap();
			CreateMap<Student, StudentCreateVM>().ReverseMap();
            CreateMap<Supervisor, SupervisorVM>().ReverseMap();
            CreateMap<Supervisor, SupervisorCreateVM>().ReverseMap();
            CreateMap<Team, TeamVM>().ReverseMap();
            CreateMap<Customer, CustomersVM>().ReverseMap();
            CreateMap<Customer, CustomerCreateVM>().ReverseMap();
            CreateMap<Workgroup, WorkgroupVM>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserCreateVM>().ReverseMap();
        }
    }
}
