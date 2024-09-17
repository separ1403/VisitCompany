using Framework.Application;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ServiceHost;

[HtmlTargetElement(Attributes = "Permission")]
public class PermissionTagHelper : TagHelper
{
    private readonly IAuthHelper _authHelper;

    public PermissionTagHelper(IAuthHelper authHelper)
    {
        _authHelper = authHelper;
    }

    public int Permission { get; set; }


    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!_authHelper.IsAuthenticated())
        {
            output.SuppressOutput();
            return;
        }

        var peermissions = _authHelper.GetPrimissions();
        if (peermissions.All(X => X != Permission))
        {
            output.SuppressOutput();
            return;
        }

        base.Process(context, output);
    }
}