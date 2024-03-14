using AkarSoft.Core.Extentions.FluentValidation.ComplexTypes;
using FluentValidation.Results;

namespace AkarSoft.Core.Extentions.FluentValidation
{
    public static class FluentValidationExtentions
    {
        public static List<CostumeErrorModel> GetErrors(this ValidationResult result)
        {
            var ErrorResults = new List<CostumeErrorModel>();

            foreach (var error in result.Errors)
            {
                ErrorResults.Add(new CostumeErrorModel() { PropertyName = error.PropertyName, ErrorDescription = error.ErrorMessage });
            }

            return ErrorResults;
            
        }

    }
}
