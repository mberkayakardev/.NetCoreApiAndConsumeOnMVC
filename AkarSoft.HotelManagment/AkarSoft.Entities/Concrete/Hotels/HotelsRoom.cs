using AkarSoft.Core.Entities.Abstract;
using Microsoft.AspNetCore.Http.Features.Authentication;

namespace AkarSoft.Entities.Concrete.Hotels
{
    public class HotelsRoom : BaseEntity
    {
        public string RoomNumber { get; set; }
        public string CoverImage { get; set; } // Kapak Fotografı 
        public int Price { get; set; } // Fiyat 
        public string Title { get; set; } // Başlık
        public string Description { get; set; } // 
        public int Stars { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public bool WifiActive { get; set; }



    }
}
