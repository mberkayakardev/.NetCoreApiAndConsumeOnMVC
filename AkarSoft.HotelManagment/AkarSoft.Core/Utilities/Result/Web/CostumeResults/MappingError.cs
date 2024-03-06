using AkarSoft.Core.Utilities.Result.Web.BaseResults;

namespace AkarSoft.Core.Utilities.Result.Web.CostumeResults
{
    public class MappingError<T> : DataResult <T>
    {
        public MappingError() : base(default, ComplexTypes.ResultStatus.MappingError, string.Empty)
        {

        }
        public MappingError(string Message) : base(default, ComplexTypes.ResultStatus.MappingError, Message)
        {

        }
    }
}
