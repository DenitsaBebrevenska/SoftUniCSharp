﻿using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace HouseRentingSystem.Attributes;

public class NotAnAgentAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        IAgentService? agentService = context
            .HttpContext
            .RequestServices
            .GetService<IAgentService>();

        if (agentService == null)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return;
        }

        var userId = context.HttpContext.User.Id();
        if (await agentService.ExistsByIdAsync(userId))
        {
            context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            return;
        }

        // Continue executing the next action delegate if all checks pass
        await next();
    }
}
