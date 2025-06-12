using AutoMapper;
using DamascusComplaintSystem.Api.DTOs;
using DamascusComplaintSystem.Api.Models;

namespace DamascusComplaintSystem.Api.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {

            CreateMap<Complaint, ComplaintDto>();

            CreateMap<Complaint, ComplaintReadDto>()
                .ForMember(dest => dest.ComplaintTypeName, opt => opt.MapFrom(src => src.ComplaintType.Name))
                .ForMember(dest => dest.ComplaintTypeArabicName, opt => opt.MapFrom(src => src.ComplaintType.ArabicName));
        }
    }
}
