using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Application.Contract.StateCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace VisitCompany.Areas.Administration.Pages.Accounts.Account
{
    [Authorize]
    public class CreateModel : PageModel
    {
        [TempData]
        public string ErrorMessageame { get; set; }

        [TempData]
        public string SuccessMessageame { get; set; }

        public SelectList Roles;

        public SelectList States;

        public RegisterAccount Command { get; set; }

        private readonly IAccountApplication _accountApplication;
        private readonly IRoleAplication _roleAplication;
        private readonly IStatecategoryApplication _statecategoryApplication;

        public CreateModel(IAccountApplication accountApplication, IRoleAplication roleAplication, IStatecategoryApplication statecategoryApplication)
        {
            _accountApplication = accountApplication;
            _roleAplication = roleAplication;
            _statecategoryApplication = statecategoryApplication;
        }

        

        private void PopulateRoles()
        {
            Roles = new SelectList(_roleAplication.List(), "Id", "Name");
        }

        private void PopulateStates()
        {
            States = new SelectList(_statecategoryApplication.List(), "Id", "Name");
        }

        [NeedsPermission(CompanyPermission.CreateAccounts)]
        public void OnGet()
        {
            SuccessMessageame = null;
            ErrorMessageame = null;
            PopulateRoles();
            PopulateStates();
        }

        [NeedsPermission(CompanyPermission.CreateAccounts)]
        public IActionResult OnPostCreate(RegisterAccount command)
        {
            if (!ModelState.IsValid)
            {
                ErrorMessageame = "لطفاً تمامی فیلدها را به درستی پر کنید.";
                PopulateRoles();
                PopulateStates();
                return Page();
            }

            if (!Regex.IsMatch(command.Mobile, @"^09\d{9}$"))
            {
                ModelState.AddModelError("Command.Mobile", "شماره موبایل باید با 09 شروع شود و 11 رقم باشد.");
                PopulateRoles();
                return Page();
            }

            // پذیرش فقط اعداد برای نام کاربری
            if (!Regex.IsMatch(command.Username, @"^\d+$"))
            {
                ModelState.AddModelError("Command.Username", "نام کاربری باید فقط شامل عدد باشد.");
                PopulateRoles();
                return Page();
            }

            var operationResult = _accountApplication.Register(command);

            if (operationResult.IsSucceeded)
            {
                SuccessMessageame = operationResult.Message;
                return RedirectToPage("./index");
            }
            else
            {
                ErrorMessageame = operationResult.Message;
                PopulateRoles();
                return Page();
            }
        }
    }
}
