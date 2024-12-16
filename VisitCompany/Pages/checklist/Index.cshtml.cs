using System.Security.Claims;
using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public IndexModel(IAccountApplication accountApplication, ICompanyApplication company,
            IChecklistApplication checklistApplication)
        {
            _accountApplication = accountApplication;
            _company = company;
            _checklistApplication = checklistApplication;
        }

        public ChecklistSearchModel SearchModel;
        public List<ChecklistViewModel> Checklists;
        public SelectList Companies;
        public SelectList Accounts;

        public SelectList TypeChecklist;
        public List<CompanyViewModel> Companiess { get; set; } 
        public List<AccountViewModel> AccountsList { get; set; }



        private readonly IAccountApplication _accountApplication;
        private readonly ICompanyApplication _company;
        private readonly IChecklistApplication _checklistApplication;



        public void OnGet(ChecklistSearchModel searchModel)
        {
            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);

            ViewData["RolesState"] = Convert.ToInt64(RolesConst.State);
            ViewData["RolesAdministrator"] = Convert.ToInt64(RolesConst.Administrator);

            Companies = new SelectList(_company.GetCompenies(), "Id", "Brand");

            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "Fullname");


            // اگر currentUserRole == Convert.ToInt64(RolesConst.State) اگر این دو تا با هم برابر بود
            //currentUserProvinceId رو هم ارسال میکنه در غیر اینصورت نال میفرسته
            Checklists = _checklistApplication.Serach(searchModel,
                 (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
               ? currentUserProvinceId
                               : (long?)null);
            //2 تا مشکل داره یکی نام ارزیاب رو نمایس نمیده تو جستجو
            //یکی هم هنگام جستجو در repository گفتم categoryid contain باشه 
            // ممکنه که عدد 1 در 11 هم باشه تست کنم ببینم چطور میشه



            Companiess = _company.Serach(
                new CompanySearchModel(), 
                (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
               ? currentUserProvinceId
                               : (long?)null);// اگر متد Serach بدون فیلتر تمام رکوردها را برگرداند

            // AccountsList = _accountApplication.Search(new AccountSearchModel()); ;
            AccountsList = _accountApplication.Search(
                new AccountSearchModel(),
                (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
                    ? currentUserProvinceId
                    : (long?)null);

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

