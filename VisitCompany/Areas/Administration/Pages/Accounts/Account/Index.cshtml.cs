using System.Security.Claims;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Application.Contract.StateCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisitCompany.Areas.Administration.Pages.Accounts.Account
{
 //   [Authorize]
    public class IndexModel : PageModel
    {

        public AccountSearchModel SearchModel;
        public List<AccountViewModel> Accounts;
        public SelectList Roles;
        public SelectList States;


        private readonly IAccountApplication _accountApplication;
        private readonly IRoleAplication _roleAplication;
        private readonly IStatecategoryApplication _statecategoryApplication;

        public IndexModel(IAccountApplication accountApplication, IRoleAplication roleAplication, IStatecategoryApplication statecategoryApplication)
        {
            _accountApplication = accountApplication;
            _roleAplication = roleAplication;
            _statecategoryApplication = statecategoryApplication;
        }


     //   [NeedsPermission(CompanyPermission.ListAccounts)]
        public void OnGet(AccountSearchModel searchModel)
        {
            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);

            Roles = new SelectList(_roleAplication.List(), "Id", "Name");
            States = new SelectList(_statecategoryApplication.List(), "Id", "Name");

            Accounts = _accountApplication.Search(searchModel, currentUserRole == Convert.ToInt64(RolesConst.State) ? currentUserProvinceId : (long?)null);
        }



        public IActionResult OnPostDisableAccount(long id)
        {
            var result = _accountApplication.DisableAccount(id); // فراخوانی متد غیرفعال کردن

            if (result.IsSucceeded)
            {
                TempData["SuccessMessageameEd"] = result.Message;
            }
            else
            {
                TempData["ErrorMessageameEd"] = result.Message;
            }

            return RedirectToPage(); // رفرش صفحه پس از عملیات
        }


        public IActionResult OnPostActivateAccount(long id)
        {
            var result = _accountApplication.EnableAccount(id); // فراخوانی متد فعال کردن

            if (result.IsSucceeded)
            {
                TempData["SuccessMessageameEd"] = result.Message;
            }
            else
            {
                TempData["ErrorMessageameEd"] = result.Message;
            }

            return RedirectToPage(); // رفرش صفحه پس از عملیات
        }



    }




}


