using AutoMapper;
using SPCS.Models;
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
