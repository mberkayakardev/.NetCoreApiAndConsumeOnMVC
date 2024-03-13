using AkarSoft.Dtos.Concrete.Rooms;
using AkarSoft.Entities.Concrete.Hotels;
using AutoMapper;

namespace AkarSoft.Managers.Concrete.MappingProfiles.Rooms
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<RoomListDto, HotelsRoom>().ReverseMap();
            CreateMap<RoomCreateDto, HotelsRoom>().ReverseMap();  

        }
    }
}
