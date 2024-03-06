using AkarSoft.Core.Entities.Abstract;

namespace AkarSoft.Entities.Concrete.Landing
{
    public class Services : BaseEntity
    {
        public string ServiceIcon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
