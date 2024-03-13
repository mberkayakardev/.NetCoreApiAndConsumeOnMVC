using AkarSoft.Entities.Concrete.Hotels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AkarSoft.Repositories.EntityFramework.Concrete.Seeds
{
    public class StaffSeeds : IEntityTypeConfiguration<Staff>
    { 

        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(new Staff
            {
                Id = 1,
                IsActive = true,
                CreatedDate = DateTime.Now,
                CreatedUser = "BERKAYAKAR",
                CreatedUserId = 1,
                ModifiedDate = DateTime.Now,
                ModifiedUserId = 1,
                ModifiedUserName = "BERKAYAKAR",
                Name = "Berkay Akar",
                Title = "Ceo",
                StaffImage = "https://berkayakar.com.tr/StaticFiles/ProfilFoto.jpg"
            });
        }

    }
}
