using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisitCompany.Areas.Administration.Pages.Accounts.Account
{
    [Authorize]
    public class IndexModel : PageModel
    {
      
        public AccountSearchModel SearchModel;
        public List<AccountViewModel> Accounts;
        public SelectList Roles;

        private readonly IAccountApplication _accountApplication ;
        private readonly IRoleAplication _roleAplication;

        public IndexModel(IAccountApplication accountApplication, IRoleAplication roleAplication)
        {
            _accountApplication = accountApplication;
            _roleAplication = roleAplication;
        }

        [NeedsPermission(CompanyPermission.ListAccounts)]
        public void OnGet(AccountSearchModel searchModel)
        {
            Roles = new SelectList(_roleAplication.List(), "Id", "Name");
            Accounts = _accountApplication.Serach(searchModel);
        }

    }




}


