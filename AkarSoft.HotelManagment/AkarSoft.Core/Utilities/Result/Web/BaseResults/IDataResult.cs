namespace AkarSoft.Core.Utilities.Result.Web.BaseResults
{
    public interface IDataResult<T> : IResult
    {
        public T Data { get; }

    }
}
