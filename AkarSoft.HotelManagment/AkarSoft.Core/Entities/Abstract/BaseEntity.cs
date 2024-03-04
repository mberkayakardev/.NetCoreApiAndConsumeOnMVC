
namespace AkarSoft.Core.Entities.Abstract
{
    public class BaseEntity : IEntity
    {
        public int Id { get ; set ; }
        public bool IsActive { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public string CreatedUserId { get ; set ; }
        public string CreatedUser { get ; set ; }
        public DateTime ModifiedDate { get ; set ; }
        public string ModifiedUser { get ; set ; }
    }
}
