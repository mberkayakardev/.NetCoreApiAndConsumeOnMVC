using AkarSoft.Dtos.Concrete.Staffs;
using AkarSoft.Entities.Concrete.Hotels;
using AutoMapper;

namespace AkarSoft.Managers.Concrete.MappingProfiles.Staff
{
    public class StaffMappingProfile : Profile
    {
        public StaffMappingProfile()
        {
            CreateMap<StaffListDto, Entities.Concrete.Hotels.Staff>().ReverseMap();
            CreateMap<StaffCreateDto, Entities.Concrete.Hotels.Staff>().ReverseMap();
        }
    }
}
