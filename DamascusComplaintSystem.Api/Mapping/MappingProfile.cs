using AutoMapper;
using DamascusComplaintSystem.Api.DTOs;
using DamascusComplaintSystem.Api.Enums;
using DamascusComplaintSystem.Api.Models;

namespace DamascusComplaintSystem.Api.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<ComplaintDto, Complaint>()
          .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (ComplaintStatus)src.ComplaintStatusId));

            CreateMap<Complaint, ComplaintDto>()
           .ForMember(dest => dest.ComplaintStatusId, opt => opt.MapFrom(src => (int)src.Status));


            CreateMap<Complaint, ComplaintDto>();


            CreateMap<Complaint, ComplaintReadDto>()
     .ForMember(dest => dest.ComplaintTypeName, opt => opt.MapFrom(src => src.ComplaintType.Name))
     .ForMember(dest => dest.ComplaintTypeArabicName, opt => opt.MapFrom(src => src.ComplaintType.ArabicName))
     .ForMember(dest => dest.ComplaintStatusName, opt => opt.MapFrom(src => src.Status.ToString()))
     .ForMember(dest => dest.ComplaintStatusArabicName, opt => opt.MapFrom(src => GetArabicStatus(src.Status)));

        }

        private string GetArabicStatus(ComplaintStatus status)
            {
                return status switch
                {
                    ComplaintStatus.Received => "تم الاستلام",
                    ComplaintStatus.UnderProcessing => "قيد المعالجة",
                    ComplaintStatus.Resolved => "تم الحل",
                    ComplaintStatus.Rejected => "مرفوضة",
                    _ => "غير معروف"
                };

        }
    }
}
