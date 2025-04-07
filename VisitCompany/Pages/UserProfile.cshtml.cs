using System.Security.Claims;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using Framework.Infrastructure;
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
        public List<CompanyViewModel> Companiess { get; set; }

        public SelectList Companies;
        public int SelectedCompanyId { get; set; }

        public List<ChecklistViewModel> CheckLists { get; set; } = new();

        private readonly IAccountApplication _accountApplication;
        private readonly IChecklistApplication _checklistApplication;
        private readonly ICompanyApplication _companyApplication;


       

        public void OnGet( )
        {

            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);

            //var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            //var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);
            //var currentUserId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "AccountId")?.Value);

            var   usernameFromSession = HttpContext.Session.GetString("CommandUsername"); // inja  az session get karde va khandeh

            if (string.IsNullOrWhiteSpace(usernameFromSession))
            {
                // Handle missing session data (could redirect, log error, etc.)
                return;
            }


            Accounts = _accountApplication.GetLastLogin(usernameFromSession);

            if (Accounts == null)
            {
                // Handle missing account (could redirect, log error, etc.)
                return;
            }

            var accountId = Accounts.Id;

            CheckLists = _checklistApplication.SerachByAccount(accountId);
            //ChecklistSearchModel searchModel = new ChecklistSearchModel();
            //  searchModel.AccountId = accountId;

            //Checklists = _checklistApplication.Serach(searchModel,
            //     (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
            //   ? currentUserProvinceId
            //                   : (long?)null);


            if (currentUserRole == Convert.ToInt64(RolesConst.Administrator)) // اگر نقش ادمین باشد
            {

                Companiess = _companyApplication.GetCompenies(); // تمام شرکت‌ها
            }

            else
            {
                Companiess = _companyApplication.Serach(
                new CompanySearchModel(),
                (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
               ? currentUserProvinceId
                               : (long?)null);//
            }


            Companies = new SelectList(Companiess ?? new List<CompanyViewModel>(), "Id", "Brand");


        }

    }
}
