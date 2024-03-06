using AkarSoft.Core.Utilities.Result.Web.BaseResults;
using AkarSoft.Core.Utilities.Result.Web.ComplexTypes;

namespace AkarSoft.Core.Utilities.Result.Web.CostumeResults
{
    public class ErrorResult<T> : DataResult<T>
    {
        public ErrorResult(string Message) : base(default, ResultStatus.Error, Message)
        {

        }
    }
}
