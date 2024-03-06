using AkarSoft.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace AkarSoft.Entities.Concrete.Identity
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
