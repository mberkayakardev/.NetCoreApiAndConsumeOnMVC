using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AkarSoft.Repositories.EntityFramework.Concrete.Contexts
{
    public class MyContexts : DbContext
    {
        public MyContexts(DbContextOptions<MyContexts> opt) : base(opt) 
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        #region DataSet




        #endregion
    }
}
