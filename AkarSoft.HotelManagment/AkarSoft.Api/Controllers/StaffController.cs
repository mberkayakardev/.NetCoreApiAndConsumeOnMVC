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

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            var result = await _staffService.GetAllPersons();
            return CreateActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonsById(int id)
        {
            return Ok("");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersons(StaffCreateDto Dto)
        {
            var result = await _staffService.CreateNewPerson(Dto);
            return CreateActionResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id)
        {
            return Ok("");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            return Ok("");
        }
    }
}
