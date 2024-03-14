using AkarSoft.Core.Dtos.Abstract;

namespace AkarSoft.Dtos.Concrete.Rooms
{
    public class RoomUpdateDto : BaseDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUserId { get; set; }
        public string CreatedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public string RoomNumber { get; set; }
        public string CoverImage { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public bool WifiActive { get; set; }
    }
}
