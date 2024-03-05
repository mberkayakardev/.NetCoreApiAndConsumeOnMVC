namespace AkarSoft.Core.Dtos.Abstract
{
    public abstract class BaseUpdateDto : BaseDto, IUpdateDto
    {
        public int Id { get ; set ; }
    }
}
