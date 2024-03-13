using AkarSoft.Entities.Concrete.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AkarSoft.Repositories.EntityFramework.Concrete.Seeds
{
    public class HotelRoomSeeds : IEntityTypeConfiguration<HotelsRoom>
    {
        public void Configure(EntityTypeBuilder<HotelsRoom> builder)
        {
            builder.HasData(
                new HotelsRoom
                {
                    Id = 1, BathCount = 2, BedCount = 3, CoverImage = "https://aremorch.com/wp-content/uploads/2016/09/The-Details-That-Matter-Top-Things-Every-Luxury-Hotel-Room-Should-Have.png", CreatedDate = DateTime.Now, CreatedUser = "BERKAYAKAR", CreatedUserId = 1, IsActive = true, ModifiedDate = DateTime.Now, ModifiedUserId = 1, ModifiedUserName = "BERKAYAKAR", Price = 1500, RoomNumber = "1A", Stars = 4, Title = "Aile Boy", WifiActive = true , Description = "Güzel bi" 
                } );
        }
    }
}
