using AkarSoft.Core.Entities.Abstract;
using AkarSoft.Entities.Concrete.Hotels;
using AkarSoft.Entities.Concrete.Identity;
using AkarSoft.Entities.Concrete.Landing;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AkarSoft.Repositories.EntityFramework.Concrete.Contexts
{
    public class MyContexts : DbContext
    {
        public MyContexts(DbContextOptions<MyContexts> opt) : base(opt) 
        {
        
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity EntityReference)
                {
                    EntityReference.ModifiedDate = DateTime.Now;
                    switch (item.State)
                    {
                        case EntityState.Added:
                            EntityReference.CreatedDate = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        #region DataSet

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<HotelsRooms> HotelsRooms {  get; set; }
        public DbSet<CarouselNews> CarouselNews {  get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }


        #endregion
    }
}
