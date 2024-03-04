namespace AkarSoft.Core.Entities.Abstract
{
    // Diğer DLLler tarafından erişilebilmesi için public tanımlanmıştır. 
    public interface IEntity
    {
        public int Id { get; set; } // Primary Key
        public bool IsActive { get; set; } // Soft Delete Property
        public DateTime CreatedDate { get; set; } // Oluşturma Tarihi
        public string CreatedUserId { get; set; }
        public string CreatedUser {  get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }


    }
}
