using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AkarSoft.Core.Utilities.LowerCaseHelper
{
    public class LowercaseControllerModelConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.ControllerName = controller.ControllerName.ToLower();
        }
    }
}
