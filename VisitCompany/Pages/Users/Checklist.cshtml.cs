
using System.Security.Claims;
using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Domain.AccountAgg;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;

namespace VisitCompany.Pages.Users
{
    [Authorize]
    public class ChecklistModel : PageModel
    {
        public ChecklistSearchModel SearchModel;
        public List<ChecklistViewModel> Checklists;
        public SelectList Companies;
        public SelectList Accounts;

        public SelectList TypeChecklist;
        public List<CompanyViewModel> Companiess { get; set; }
        public List<CompanyViewModel> CompaniessByAccount { get; set; }

        public List<AccountViewModel> AccountsList { get; set; }
        public SelectList CompanyCategories { get; set; }



        private readonly IAccountApplication _accountApplication;
        private readonly ICompanyApplication _company;
        private readonly IChecklistApplication _checklistApplication;
        private readonly ICompanyCategoryApplication _companyCategoryApplication;

        public ChecklistModel(IAccountApplication accountApplication, ICompanyApplication company, IChecklistApplication checklistApplication, ICompanyCategoryApplication companyCategoryApplication)
        {
            _accountApplication = accountApplication;
            _company = company;
            _checklistApplication = checklistApplication;
            _companyCategoryApplication = companyCategoryApplication;
        }

        public void OnGet(ChecklistSearchModel searchModel)
        {
            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);
            var currentUserId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "AccountId")?.Value);
            LoadDropdowns();

            // مقداردهی اولیه برای نمایش تمام رکوردها در بار اول
            Checklists = _checklistApplication.Serach(
      new ChecklistSearchModel(),
      (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
      ? currentUserProvinceId
      : null // مقدار جایگزین برای حالت false
  ) ?? new List<ChecklistViewModel>();




            //Companiess = _company.Serach(
            //   new CompanySearchModel(),
            //   (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
            //  ? currentUserProvinceId
            //                   : null) ?? new List<CompanyViewModel>();

            Companiess = _company.Serach(
             new CompanySearchModel(),
             (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
            ? currentUserProvinceId
                            : (long?)null);//

            AccountsList = _accountApplication.Search(new AccountSearchModel(), null) ?? new List<AccountViewModel>();
        }



        public IActionResult OnPost(ChecklistSearchModel searchModel)
        {
            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);
            var currentUserId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "AccountId")?.Value);


            ViewData["RolesState"] = Convert.ToInt64(RolesConst.State);
            ViewData["RolesAdministrator"] = Convert.ToInt64(RolesConst.Administrator);

            LoadDropdowns();
            Checklists = _checklistApplication.Serach(searchModel, null) ?? new List<ChecklistViewModel>();
            Companiess = _company.Serach(new CompanySearchModel(), null) ?? new List<CompanyViewModel>();
            AccountsList = _accountApplication.Search(new AccountSearchModel(), null) ?? new List<AccountViewModel>();

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
                                              //فقط فیلتر سطح دسترسی را اعمال می‌کنیم، فیلتر کاربران در متد Serach انجام می‌شود


            // فقط شرکت‌هایی که کاربر در آن‌ها حساب دارد نمایش داده شود
            // این برای اینه که تو داشبور کاربرای عادی بخواهیم لیست شرکت ها را نمایش بدیم
            CompaniessByAccount = _company.SerachByAccount(
                 new CompanySearchModel(),
                 currentUserId: currentUserId // ارسال شناسه حساب کاربر
             );


            // AccountsList = _accountApplication.Search(new AccountSearchModel()); ;
            AccountsList = _accountApplication.Search(
                new AccountSearchModel(),
                (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
                    ? currentUserProvinceId
                    : (long?)null);

            return Page();

        }

        public IActionResult OnGetDetails(int id)
        {
            if (id == 0)
                return Content("Invalid ID received");

            var company = _company.Getdetailpartial(id);
            if (company == null)
                return Content("اطلاعات شرکت یافت نشد.");

            return Partial("_CompanyDetails", company);
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



        private void LoadDropdowns()
        {
            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);

            ViewData["RolesState"] = Convert.ToInt64(RolesConst.State);
            ViewData["RolesAdministrator"] = Convert.ToInt64(RolesConst.Administrator);


            if (currentUserRole == Convert.ToInt64(RolesConst.Administrator)) // اگر نقش ادمین باشد
            {

                Companiess = _company.GetCompenies(); // تمام شرکت‌ها
            }

            else
            {
                Companiess = _company.Serach(
                new CompanySearchModel(),
                (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
               ? currentUserProvinceId
                               : (long?)null);//
            }


            Companies = new SelectList(Companiess ?? new List<CompanyViewModel>(), "Id", "Brand");
            //      Accounts = new SelectList(_accountApplication.GetAccounts() ?? new List<AccountViewModel>(), "Id", "Fullname");

            var accounts = _accountApplication.GetAccounts(
    (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
    ? currentUserProvinceId
    : (long?)null
);

            Accounts = new SelectList(accounts ?? new List<AccountViewModel>(), "Id", "Fullname");


            CompanyCategories = new SelectList(_companyCategoryApplication.GetCompanyCategories() ?? new List<CompanyCategoryViewModel>(), "Id", "Name");
        }


    }
}

