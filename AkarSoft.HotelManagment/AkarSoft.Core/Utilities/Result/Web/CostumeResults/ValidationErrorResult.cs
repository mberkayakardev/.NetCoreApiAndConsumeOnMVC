using AkarSoft.Core.Extentions.FluentValidation.ComplexTypes;
using AkarSoft.Core.Utilities.Result.Web.BaseResults;
using AkarSoft.Core.Utilities.Result.Web.ComplexTypes;

namespace AkarSoft.Core.Utilities.Result.Web.CostumeResults
{
    public class ValidationErrorResult<T> : DataResult<T>
    {
        public ValidationErrorResult(IEnumerable<CostumeErrorModel> Errors) : base(default, ResultStatus.ValidationError, Errors)
        {

        }
    }
}
