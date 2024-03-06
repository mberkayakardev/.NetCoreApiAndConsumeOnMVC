using AkarSoft.Managers.Concrete.MappingProfiles.Rooms;
using AkarSoft.Repositories.EntityFramework.Abstract;
using AkarSoft.Repositories.EntityFramework.Concrete.Contexts;
using AkarSoft.Repositories.EntityFramework.Concrete.UOW;
using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace AkarSoft.Managers.Concrete.DependencyResolves.AutoFac
{
    public class AutoFacModule : Autofac.Module
    {
        private readonly IConfiguration configuration;
        private readonly IHostEnvironment Environment;
        public AutoFacModule(IConfiguration configuration, IHostEnvironment env)
        {
            this.configuration = configuration;
            this.Environment = env;
        }



        protected override void Load(ContainerBuilder builder)
        {
            AddDbContext(builder, configuration, Environment);

            AddUnitOfWork(builder);

            AddAutoMapper(builder);




            // Development ve Prod ortamlarına göre loglama gibi bazı dinamikleri ayrıştırabilmek maksatlı bu şekilde bir ayrışım oluşturulmuştur. 


            base.Load(builder);

        }

        /// <summary>
        ///  Dbcontext için runtime da migration ları otomatik olarak veritabanına yansıtmak için kullanılır ( sadece development modunda çalışır ... )
        /// </summary>
        #region DbContext Configuration
        private static void AddDbContext(ContainerBuilder builder, IConfiguration configuration, IHostEnvironment Environment)
        {
            builder.Register(x =>
            {
                var opt = new DbContextOptionsBuilder<MyContexts>();

                opt.UseSqlServer(configuration.GetConnectionString("SqlServer").ToString());

                var context = new MyContexts(opt.Options);

                if (Environment.IsDevelopment())
                    context.Database.Migrate();

                return context;

            }).InstancePerLifetimeScope();

        }
        #endregion

        /// <summary>
        /// Unit Of Work Ayarlaması için yapılmış olan bir yapıdır
        /// </summary>
        #region UnitOfWork Implementation 
        private static void AddUnitOfWork(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
        #endregion

        /// <summary>
        /// AutoMapper Kaydı için gerçekleşmektedir.
        /// </summary>
        #region AutoMapper 
        private static void AddAutoMapper(ContainerBuilder builder)
        {
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                var AssemblyList = Assembly.GetExecutingAssembly().GetTypes();
                // AutoMapper profil(eri)lerini kaydet
                //cfg.AddProfile(new RoomMappingProfile()); // YourMappingProfile yerine kendi profil sınıfınızın adını kullanın
            })).AsSelf().SingleInstance();


            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }

        #endregion
    }
}
