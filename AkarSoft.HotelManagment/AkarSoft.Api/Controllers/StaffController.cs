using AkarSoft.Core.Utilities.CostumeBaseControl.Api;
using AkarSoft.Dtos.Concrete.Staffs;
using AkarSoft.Managers.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AkarSoft.Api.Controllers
{
    public class StaffController : ApiBaseController
    {
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet] // Tamamlandi
        public async Task<IActionResult> GetAllPersons()
        {
            var result = await _staffService.GetAllPersons();
            return CreateActionResult(result);
        }

        [HttpGet("/active")] // Tamamlandi
        public async Task<IActionResult> GetAllActivePersons()
        {
            var result = await _staffService.GetAllPersons();
            return CreateActionResult(result);
        }

        [HttpGet("{id}")] // Tamamlandi
        public async Task<IActionResult> GetPersonsById(int id)
        {
            var result = await _staffService.GetPersonsById(id);
            return CreateActionResult(result);
        }

        [HttpPost] // Tamamalandi 
        public async Task<IActionResult> CreatePersons(StaffCreateDto Dto)
        {
            var result = await _staffService.CreateNewPerson(Dto);
            return CreateActionResult(result);
        }


        [HttpPut("{id}")] //Tamamlandi
        public async Task<IActionResult> UpdatePerson(StaffUpdateDto dto)
        {
            var result = await _staffService.UpdatePersonDto(dto);
            return CreateActionResult(result);
        }


        [HttpDelete("{id}")] // Tamamlandi 
        public async Task<IActionResult> DeletePerson(int id)
        {
            var result = await _staffService.DeletedPersonSafe(id);
            return CreateActionResult(result);
        }
    }
}
