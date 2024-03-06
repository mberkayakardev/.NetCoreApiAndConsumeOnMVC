using AkarSoft.Core.Utilities.Result.Web.BaseResults;
using AkarSoft.Core.Utilities.Result.Web.ComplexTypes;

namespace AkarSoft.Core.Utilities.Result.Web.CostumeResults
{
    public class NotFoundResult<T> : DataResult<T>
    {
        public NotFoundResult(string Message) : base(default, ResultStatus.NotFound, Message)
        {

        }
        public NotFoundResult() : base(default, ResultStatus.NotFound)
        {

        }
    }
}
