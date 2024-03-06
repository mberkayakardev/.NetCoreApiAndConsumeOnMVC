using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AkarSoft.Managers.Concrete.DependencyResolves.MicrosoftIOC
{
    public static class MicrosoftIOCConatiner
    {
        /// <summary>
        ///  Bağımlılık ve Services implementasyonu için istenildiği taktirde AutoFac istenildiği taktirde Microsoft IOC kullanılabilir. Projede Autofac kullanılacak olsa dahi klasörleme yapısına uyulması için bu şekilde bir yapılandırma yapıldı. 
        /// </summary>
        public static void AddCostumeServicesMicrosoftIOC(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
