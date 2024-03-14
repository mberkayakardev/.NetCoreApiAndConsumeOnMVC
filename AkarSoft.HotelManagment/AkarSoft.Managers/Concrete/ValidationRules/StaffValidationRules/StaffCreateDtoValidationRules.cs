using AkarSoft.Dtos.Concrete.Staffs;
using FluentValidation;

namespace AkarSoft.Managers.Concrete.ValidationRules.StaffValidationRules
{
    public class StaffCreateDtoValidationRules : AbstractValidator<StaffCreateDto>
    {
        public StaffCreateDtoValidationRules()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Personel Ünvanı boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Personel Adı Boş geçilemez");

        }
    }
}
