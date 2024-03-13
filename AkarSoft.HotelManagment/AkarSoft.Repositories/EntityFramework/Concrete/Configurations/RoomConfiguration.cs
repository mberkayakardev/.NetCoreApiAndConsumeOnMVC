using AkarSoft.Entities.Concrete.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AkarSoft.Repositories.EntityFramework.Concrete.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<HotelsRoom>
    {
        public void Configure(EntityTypeBuilder<HotelsRoom> builder)
        {
            builder.Property(x=> x.RoomNumber).HasMaxLength(200);
            builder.Property(x => x.Price).HasPrecision(10,0);
            builder.Property(x => x.Price).HasAnnotation("Range", new[] {0,150000});
            builder.Property(x => x.Title).HasMaxLength(1500);

        }
    }
}
