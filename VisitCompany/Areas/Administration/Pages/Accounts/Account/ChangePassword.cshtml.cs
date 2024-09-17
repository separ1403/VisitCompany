using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisitCompany.Areas.Administration.Pages.Accounts.Account
{
    [Authorize]
    public class ChangePasswordModel : PageModel
    {
        [TempData] public string ErrorMessageameEd { get; set; }

        [TempData] public string SuccessMessageameEd { get; set; }

        private static long intvc;

        public ChangePassword Command { get; set; }
        public SelectList Roles;
        private readonly IAccountApplication _accountApplication;

        public ChangePasswordModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        [NeedsPermission(CompanyPermission.CreateAccounts)]
        public void OnGet(long id)
        {

           // intvc = id;
            Command = _accountApplication.Getdetail(id);

        }

        public IActionResult OnPostChangePassword(ChangePassword command)
        {
            var operationResult = _accountApplication.ChangePassword(command);



            if (operationResult.IsSucceeded)

                SuccessMessageameEd = operationResult.Message;

            else

                ErrorMessageameEd = operationResult.Message;

            return RedirectToPage("./Index");

        }
    }
}
