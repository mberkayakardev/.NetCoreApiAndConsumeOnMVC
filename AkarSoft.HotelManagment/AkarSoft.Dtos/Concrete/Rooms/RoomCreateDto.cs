using Microsoft.AspNetCore.Http;

namespace AkarSoft.Dtos.Concrete.Rooms
{
    public class RoomCreateDto
    {
        public string CreatedUserId { get; set; }
        public string RoomNumber { get; set; }
        public IFormFile CoverImage { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public bool WifiActive { get; set; }
    }
}
