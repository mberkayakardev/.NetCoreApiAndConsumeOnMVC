using AkarSoft.Core.Dtos.Abstract;

namespace AkarSoft.Dtos.Concrete.Staffs
{
    public class StaffListDto: IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string StaffImage { get; set; }
    }
}
