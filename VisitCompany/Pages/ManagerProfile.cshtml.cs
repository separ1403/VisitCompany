using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages
{
    [Authorize]

    public class ManagerProfileModel : PageModel
    {
        [NeedsPermission(CompanyPermission.CreateAccounts)]

        public void OnGet()
        {
        }
    }
}
