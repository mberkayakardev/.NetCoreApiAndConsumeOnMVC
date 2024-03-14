using AkarSoft.Core.Dtos.Abstract;
using Microsoft.AspNetCore.Http;

namespace AkarSoft.Dtos.Concrete.Staffs
{
    public class StaffCreateDto : IDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public IFormFile StaffImage { get; set; }

    }
}
