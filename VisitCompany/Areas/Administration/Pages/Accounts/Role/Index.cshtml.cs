using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Areas.Administration.Pages.Accounts.Role  
{
    [Authorize]
    public class IndexModel : PageModel
    {
      
        
        public List<RoleViewModel> Roles;
       

       
        private readonly IRoleAplication _roleAplication;

        public IndexModel( IRoleAplication roleAplication)
        {
            
            _roleAplication = roleAplication;
        }
        [NeedsPermission(CompanyPermission.ListRoles)]
        public void OnGet()
        {

            Roles = _roleAplication.List();
        }

    }




}


