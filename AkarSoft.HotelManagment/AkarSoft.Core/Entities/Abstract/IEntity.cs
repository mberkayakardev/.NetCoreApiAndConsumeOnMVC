namespace AkarSoft.Core.Entities.Abstract
{
    // Diğer DLLler tarafından erişilebilmesi için public tanımlanmıştır. 
    public interface IEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public string CreatedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedUserId { get; set; }
        public string ModifiedUserName { get; set; }

    }
}
