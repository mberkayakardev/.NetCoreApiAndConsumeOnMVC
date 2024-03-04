using System.Text.Json.Serialization.Metadata;

namespace AkarSoft.Core.Dtos.Abstract
{
    public interface IUpdateDto : IDto
    {
        public int Id { get; set; } // Sistemdeki tüm dto lar idto ya bağlıdır. Update işlemini üstlenecek DTO lar için id değeri varsayılanda olabilmesi için bu şekilde bir yapılandırma yapılmıştır 
    }
}
