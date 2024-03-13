using AkarSoft.Managers.Abstract;
using AkarSoft.Managers.Concrete.Managers;
using AkarSoft.Managers.Concrete.MappingProfiles.Rooms;
using AkarSoft.Repositories.EntityFramework.Abstract;
using AkarSoft.Repositories.EntityFramework.Concrete.Contexts;
using AkarSoft.Repositories.EntityFramework.Concrete.UOW;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Xml.Serialization;

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

            AddDependencies(builder);

            AppConfiguration(builder);





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
        /// AutoMapper Kaydı için gerçekleşmektedir. Reflectionlar ile bu Manager DLL i için geçerli olan bir koddur. Yeni pofile leri elle eklemeneize gerek yok ilgili işlem otomatik gerçekleşmekte 
        /// </summary>
        #region AutoMapper 
        private static void AddAutoMapper(ContainerBuilder builder)
        {


            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                var AssemblyList2 = Assembly.Load(Assembly.GetExecutingAssembly().FullName).GetTypes().Where(x => x.BaseType == typeof(Profile)).ToList();
                foreach (var item in AssemblyList2)
                {
                    cfg.AddProfile(item);

                }

            })).AsSelf().SingleInstance();

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }

        #endregion

        /// <summary>
        /// Costume bir şekilde oluşturulmuş olan Servislerinizin implementasyonlarını gerçekleştirebilirsiniz. 
        /// </summary>
        #region Costume Dependencies 
        private static void AddDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<RoomManager>().As<IRoomService>().InstancePerLifetimeScope();   // Scoped 
            builder.RegisterType<StaffManager>().As<IStaffService>().InstancePerLifetimeScope(); // Scoped 
        }
        #endregion

        /// <summary>
        /// Uygulama Konfigürasyonlarının ekleneceği bir alandır (IHttpcontextAccessor, Login Logout .... )
        /// </summary>
        /// <param name="builder"></param>
        #region AppConfiguration

        private static void AppConfiguration(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().InstancePerLifetimeScope();
        }


        #endregion

    }
}
