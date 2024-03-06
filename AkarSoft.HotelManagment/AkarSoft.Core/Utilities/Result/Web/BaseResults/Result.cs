using AkarSoft.Core.Extentions.FluentValidation.ComplexTypes;
using AkarSoft.Core.Utilities.Result.Web.ComplexTypes;

namespace AkarSoft.Core.Utilities.Result.Web.BaseResults
{
    public class Result : IResult
    {
        public ResultStatus Status { get; }

        public string Messages { get; }

        public IEnumerable<CostumeErrorModel> ValidationErrors { get; }

        public Result(ResultStatus status, string StatusMessages, IEnumerable<CostumeErrorModel> Errors) : this(status, StatusMessages)
        {
            ValidationErrors = Errors;
        }

        public Result(ResultStatus status, string StatusMessages) : this(status)
        {
            this.Messages = StatusMessages;
        }

        public Result(ResultStatus status)
        {
            this.Status = status;
        }

        public Result(ResultStatus status, IEnumerable<CostumeErrorModel> Errors) : this(status, string.Empty, Errors)
        {

        }
    }
}
