using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace HouseRentingSystem.Attributes;

public class UserIsTheHouseAgentOrAdminAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        IHouseService? houseService = context
            .HttpContext
            .RequestServices
            .GetService<IHouseService>();

        if (houseService == null)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return;
        }

        string houseId = context.RouteData.Values["id"]?.ToString() ?? "";

        if (!int.TryParse(houseId, out int result))
        {
            context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
        }

        if (!await houseService.HasAgentWithIdAsync(result, context.HttpContext.User.Id()) &&
            !context.HttpContext.User.IsAdmin())
        {
            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            return;
        }

        await next();
    }
}
