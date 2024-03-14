using AkarSoft.Dtos.Concrete.Staffs;
using FluentValidation;

namespace AkarSoft.Managers.Concrete.ValidationRules.StaffValidationRules
{
    public class StaffUpdateDtoValidator : AbstractValidator<StaffUpdateDto>
    {
        public StaffUpdateDtoValidator()
        {
            RuleFor(x => x.Id).ExclusiveBetween(1, int.MaxValue).WithMessage("Güncellenecek personel için geçerli bir id değeri veriniz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Personel Ünvanı boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Personel Adı Boş geçilemez");
        }
    }
}
