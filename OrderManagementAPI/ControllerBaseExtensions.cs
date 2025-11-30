using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI;

public static class ControllerBaseExtensions
{
    public static void HandleParametersCheck(this ControllerBase controllerBase, string parameterName)
    {
        if (IsModelNotValid(controllerBase))
        {
            throw new ArgumentException(parameterName);
        }
    }

    private static bool IsModelNotValid(ControllerBase controllerBase)
    {
        return !controllerBase.ModelState.IsValid;
    }
}
