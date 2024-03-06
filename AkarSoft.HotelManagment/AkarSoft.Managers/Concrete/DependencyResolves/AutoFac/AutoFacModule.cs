using AkarSoft.Repositories.EntityFramework.Concrete.Contexts;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AkarSoft.Managers.Concrete.DependencyResolves.AutoFac
{
    public class AutoFacModule : Autofac.Module
    {
        private readonly IConfiguration configuration;
        public AutoFacModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(x =>
            {
                var opt = new DbContextOptionsBuilder<MyContexts>();
                opt.UseSqlServer(configuration.GetConnectionString("SqlServer").ToString());
                return new MyContexts(opt.Options);
            }).InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
