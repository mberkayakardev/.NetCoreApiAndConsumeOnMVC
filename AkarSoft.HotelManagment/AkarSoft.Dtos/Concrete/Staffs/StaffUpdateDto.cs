using AkarSoft.Core.Dtos.Abstract;
using Microsoft.AspNetCore.Http;

namespace AkarSoft.Dtos.Concrete.Staffs
{
    public class StaffUpdateDto : BaseUpdateDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public IFormFile StaffNewImage { get; set; }
        public string StaffCurrentImage { get; set; }

    }
}
