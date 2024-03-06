using AkarSoft.Core.Extentions.FluentValidation.ComplexTypes;
using AkarSoft.Core.Utilities.Result.Web.ComplexTypes;

namespace AkarSoft.Core.Utilities.Result.Web.BaseResults
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }
        public DataResult(T data, ResultStatus status, string Messages) : base(status, Messages)
        {
            this.Data = data;
        }
        public DataResult(T data, ResultStatus status) : base(status)
        {
            this.Data = data;

        }
        public DataResult(T data, ResultStatus status, IEnumerable<CostumeErrorModel> Errors) : base(status, "", Errors)
        {
            this.Data = data;

        }

    }
}
