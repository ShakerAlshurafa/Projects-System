using AutoMapper;
using SPCS.Models.project;
using SPCS.ViewModel;

namespace SPCS.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectVM>().ReverseMap();
            CreateMap<Project, ProjectDetailsVM>().ReverseMap();
        }
    }
}
