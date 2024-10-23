using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Application.Contract.StateCategory;
using CompanyManagement.Domain.StatesCategoryAgg;
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
    public class EditModel : PageModel
    {

        [TempData]
        public string ErrorMessageameEd { get; set; }

        [TempData]
        public string SuccessMessageameEd { get; set; }

       
        public EditAccount Command {get; set; }
        public SelectList Roles;
        public SelectList States;

        private readonly IAccountApplication _accountApplication;
        private readonly IRoleAplication _roleAplication;
        private readonly IStatecategoryApplication _statecategoryApplication;

        public EditModel(IAccountApplication accountApplication, IRoleAplication roleAplication, IStatecategoryApplication statecategoryApplication)
        {
            _accountApplication = accountApplication;
            _roleAplication = roleAplication;
            _statecategoryApplication = statecategoryApplication;
        }

        [NeedsPermission(CompanyPermission.EditAccounts)]
        public void OnGet(long id)
        {

            Command = _accountApplication.Getdetails(id);
            Roles = new SelectList(_roleAplication.List(), "Id", "Name");
            States = new SelectList(_statecategoryApplication.List(), "Id", "Name");
        }
        [NeedsPermission(CompanyPermission.EditAccounts)]
        public IActionResult  OnPostEdit(EditAccount command)
        {
            var operationResult = _accountApplication.Edit(command);


            if (operationResult.IsSucceeded)
            {
                SuccessMessageameEd = operationResult.Message;
            }
            else
            {
                ErrorMessageameEd = operationResult.Message;
            }

            return RedirectToPage("./Index");

        }
    }
}
