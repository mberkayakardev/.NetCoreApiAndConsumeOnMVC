using AkarSoft.Core.Utilities.Result.Api;
using AkarSoft.Core.Utilities.Result.Api.ComplexTypes;
using AkarSoft.Dtos.Concrete.Rooms;
using AkarSoft.Entities.Concrete.Hotels;
using AkarSoft.Managers.Abstract;
using AkarSoft.Managers.Concrete.ConstVerables;
using AkarSoft.Repositories.EntityFramework.Abstract;
using AutoMapper;

namespace AkarSoft.Managers.Concrete.Managers
{
    public class RoomManager : BaseManager, IRoomService
    {
        public RoomManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public async Task<ApiResponseDto<RoomListDto>> CreateNewRoom(RoomCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponseDto<List<RoomListDto>>> GetAllRooms()
        {
            var repository = _unitOfWork.GetGenericRepositories<HotelsRoom>();
            var result = await repository.GetAllAsync();
            if (result == null ||  result.Count == 0)
                return ApiResponseDto<List<RoomListDto>>.FailResult(Messages.Status.Success, ApiResponseStatus.NotFound);

            var mappingresult = _mapper.Map<List<RoomListDto>>(result);
            if (mappingresult == null || mappingresult.Count == 0 )
                return ApiResponseDto<List<RoomListDto>>.FailResult(Messages.Status.Success, ApiResponseStatus.NotFound);

            return ApiResponseDto<List<RoomListDto>>.SuccessResult(ApiResponseStatus.OK, mappingresult);

        }
    }
}
