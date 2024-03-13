using AkarSoft.Core.Utilities.Result.Api;
using AkarSoft.Dtos.Concrete.Rooms;

namespace AkarSoft.Managers.Abstract
{
    public interface IRoomService
    {
        public Task<ApiResponseDto<List<RoomListDto>>> GetAllRooms();
        public Task<ApiResponseDto<RoomListDto>> CreateNewRoom(RoomCreateDto dto);

    }
}
