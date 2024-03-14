using AkarSoft.Core.Dtos.Concrete;
using AkarSoft.Core.Utilities.Result.Api;
using AkarSoft.Dtos.Concrete.Rooms;
using AkarSoft.Dtos.Concrete.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkarSoft.Managers.Abstract
{
    public interface IStaffService
    {
        public Task<ApiResponseDto<List<StaffListDto>>> GetAllPersons();
        public Task<ApiResponseDto<StaffListDto>> GetPersonsById(int id);
        public Task<ApiResponseDto<List<StaffListDto>>> GetAllActivePersons();
        public Task<ApiResponseDto<StaffListDto>> CreateNewPerson(StaffCreateDto dto); // Kayıt işlemi sonrası id dönebilmek için StaffListDto döndüldü.  
        public Task<ApiResponseDto<NoContentDto>> UpdatePersonDto(StaffUpdateDto dto);
        public Task<ApiResponseDto<NoContentDto>> DeletedPersonSafe(int id);

    }
}
