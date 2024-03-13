using AkarSoft.Core.Utilities.CostumeBaseControl.Api;
using AkarSoft.Dtos.Concrete.Rooms;
using AkarSoft.Managers.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AkarSoft.Api.Controllers
{
    public class RoomController : ApiBaseController
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var result = await _roomService.GetAllRooms();
            return CreateActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomCreateDto createDto)
        {
            var result = await _roomService.CreateNewRoom(createDto);
            return CreateActionResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            return Ok();
        }


    }
}
