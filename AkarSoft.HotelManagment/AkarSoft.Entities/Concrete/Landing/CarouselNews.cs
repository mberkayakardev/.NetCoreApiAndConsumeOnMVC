using AkarSoft.Core.Entities.Abstract;

namespace AkarSoft.Entities.Concrete.Landing
{
    public class CarouselNews : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string ShowTitle { get; set; }
        public string ShowDescription { get; set; }
        public string Link { get; set; }
        public int Order {  get; set; }
    }
}
