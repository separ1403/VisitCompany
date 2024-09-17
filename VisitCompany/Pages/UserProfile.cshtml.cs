using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisitCompany.Pages
{
    [Authorize]
    public class UserProfileModel : PageModel
    {
        public UserProfileModel(IAccountApplication accountApplication, IChecklistApplication checklistApplication, ICompanyApplication companyApplication)
        {
            _accountApplication = accountApplication;
            _checklistApplication = checklistApplication;
            _companyApplication = companyApplication;
        }


        public AccountViewModel Accounts;

        public SelectList Companies;
        public int SelectedCompanyId { get; set; }

        public List<ChecklistViewModel> CheckLists;

        private readonly IAccountApplication _accountApplication;
        private readonly IChecklistApplication _checklistApplication;
        private readonly ICompanyApplication _companyApplication;


       

        public void OnGet( )
        {
            string  usernameFromSession = HttpContext.Session.GetString("CommandUsername"); // inja  az session get karde va khandeh

            Accounts = _accountApplication.GetLastLogin(usernameFromSession);
            var accountId = Accounts.Id;

            CheckLists = _checklistApplication.SerachByAccount(accountId);
            Companies = new SelectList(_companyApplication.GetCompeniesWithUsername(), "Id", "Brand");

        }

    }
}
