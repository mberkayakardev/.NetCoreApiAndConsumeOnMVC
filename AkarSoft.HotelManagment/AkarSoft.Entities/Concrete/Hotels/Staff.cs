using AkarSoft.Core.Entities.Abstract;

namespace AkarSoft.Entities.Concrete.Hotels
{
    public class Staff : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string StaffImage { get; set; }

    }
}
