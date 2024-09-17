using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace ServiceHost;

public class SecurityPageFilter : IPageFilter //part29 sess 16
{
    private readonly IAuthHelper _authHelper;

    public SecurityPageFilter(IAuthHelper authHelper)
    {
        _authHelper = authHelper;
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        var handlerMethodDescriptor = context.HandlerMethod;

        if (handlerMethodDescriptor == null)
            return;

        var handlerPermission = handlerMethodDescriptor.MethodInfo.GetCustomAttribute<NeedsPermissionAttribute>();

        if (handlerPermission == null)
            return;

        var accountPermissions = _authHelper.GetPrimissions();

        if (!accountPermissions.Contains(handlerPermission.Permission))
        {
            context.HttpContext.Response.Redirect("/Account");
        }
    }




    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
    }
}