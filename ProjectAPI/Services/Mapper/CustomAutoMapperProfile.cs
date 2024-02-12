using AutoMapper;
using ProjectAPI.DTOs;
using ProjectAPI.Models;

namespace ProjectAPI.Services.Mapper
{
    public class CustomAutoMapperProfile : Profile
    {
        public CustomAutoMapperProfile()
        {
            CreateMap<Project, ProjectDTO>()
                .ForMember(dest => dest.UIID, opt => opt.MapFrom(src => src.GUID))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => ConvertStringToDateTime(src.Date)));

            CreateMap<ProjectDTO, Project>()
                .ForMember(dest => dest.GUID, opt => opt.MapFrom(src => src.UIID))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd")))
                .ReverseMap();
        }

        private DateTime ConvertStringToDateTime(string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime result))
            {
                return result;
            }
            return DateTime.MinValue;
        }
    }
}
