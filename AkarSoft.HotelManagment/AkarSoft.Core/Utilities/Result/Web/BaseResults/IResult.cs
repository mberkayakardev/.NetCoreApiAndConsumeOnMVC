using AkarSoft.Core.Extentions.FluentValidation.ComplexTypes;
using AkarSoft.Core.Utilities.Result.Web.ComplexTypes;

namespace AkarSoft.Core.Utilities.Result.Web.BaseResults
{
    /// <summary>
    ///  MVC, Razor Page gibi result gibi yapılarda ilgili nesneyi dönmeniz tavsiye edilir. İsteğe bağlı kalınarak Api Projeleri içinde tercih edilebilir. 
    /// </summary>
    public interface IResult
    {
        public ResultStatus Status { get; }
        public string Messages { get; }
        public IEnumerable<CostumeErrorModel> ValidationErrors { get; }

    }
}
