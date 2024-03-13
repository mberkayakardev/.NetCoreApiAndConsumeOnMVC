using AkarSoft.Entities.Concrete.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AkarSoft.Repositories.EntityFramework.Concrete.Configurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
       
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired(true);
             
        }
    }
}
