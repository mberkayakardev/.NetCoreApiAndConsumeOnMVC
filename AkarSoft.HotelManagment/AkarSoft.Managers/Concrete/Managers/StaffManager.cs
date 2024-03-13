using AkarSoft.Core.Utilities.Result.Api;
using AkarSoft.Core.Utilities.Result.Api.ComplexTypes;
using AkarSoft.Dtos.Concrete.Staffs;
using AkarSoft.Entities.Concrete.Hotels;
using AkarSoft.Managers.Abstract;
using AkarSoft.Managers.Concrete.ConstVerables;
using AkarSoft.Repositories.EntityFramework.Abstract;
using AutoMapper;

namespace AkarSoft.Managers.Concrete.Managers
{
    public class StaffManager : BaseManager, IStaffService
    {
        public StaffManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public async Task<ApiResponseDto<List<StaffListDto>>> GetAllPersons()
        {
            var repository = _unitOfWork.GetGenericRepositories<Staff>();
            var result = await repository.GetAllAsync();
            
            if (result == null || result.Count == 0)
                return ApiResponseDto<List<StaffListDto>>.FailResult(Messages.Status.NotFound, ApiResponseStatus.NotFound);

            var mappingresult = _mapper.Map<List<StaffListDto>>(result);

            return ApiResponseDto<List<StaffListDto>>.SuccessResult(ApiResponseStatus.OK, mappingresult);

        }
    }
}
