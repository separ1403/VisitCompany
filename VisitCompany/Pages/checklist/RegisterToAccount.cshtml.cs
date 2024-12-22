using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Infrasructure.EFCore.Migrations;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace VisitCompany.Pages.checklist
{
    public class RegisterToAccountModel : PageModel
    {
        public SelectList Accounts { get; set; }
        public List<AccountViewModel> AccountsList { get; set; }

        public CompanySearchModel SearchModel { get; set; }
        public List<CompanyViewModel> Companies  { get; set; } = new List<CompanyViewModel>();
        public SelectList CompanyCategories { get; set; }
        public SelectList LicenceCategories { get; set; }

        public List<SelectListItem> AccountList = new List<SelectListItem>();
        public BatchEditCompany Command { get; set; }


        private readonly ICompanyApplication _company;
        private readonly ICompanyCategoryApplication _companyCategoryApplication;
        private readonly ILicenceCategoryApplication _licenceCategoryApplication;
        private readonly IAccountApplication _accountApplication;

        public RegisterToAccountModel(
            ICompanyApplication company,
            ICompanyCategoryApplication companyCategoryApplication,
            ILicenceCategoryApplication licenceCategoryApplication,
            IAccountApplication accountApplication)
        {
            _company = company;
            _companyCategoryApplication = companyCategoryApplication;
            _licenceCategoryApplication = licenceCategoryApplication;
            _accountApplication = accountApplication;
        }


        [NeedsPermission(CompanyPermission.ReferCompanies)]
        public void OnGet()
        {
            PopulateSelectLists();

            // بررسی نقش کاربر
            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);

            // مقداردهی اولیه لیست‌ها برای نمایش در dropdown ها
            CompanyCategories = new SelectList(_companyCategoryApplication.GetCompanyCategories(), "Id", "Name");
            LicenceCategories = new SelectList(_licenceCategoryApplication.GetLicenceCategories(), "Id", "Name");


            if (currentUserRole == Convert.ToInt64(RolesConst.Administrator)) // اگر نقش ادمین باشد
            {
                

                Companies = _company.GetCompenies(); // تمام شرکت‌ها
            }
            else if (currentUserRole == Convert.ToInt64(RolesConst.State)) // اگر نقش ادمین استانی باشد
            {
                Companies = _company.Serach(new CompanySearchModel(),currentUserProvinceId); // شرکت‌های مربوط به استان
            }
            else 
            {
                Companies = null;
            }
            
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


        [NeedsPermission(CompanyPermission.ListCompanies)]
        public void OnPost(CompanySearchModel searchModel)
        {
            // دوباره مقداردهی لیست‌ها در صورت نیاز (معمولاً برای مواردی که فرم ری‌پست می‌شود)
            CompanyCategories = new SelectList(_companyCategoryApplication.GetCompanyCategories(), "Id", "Name");
            LicenceCategories = new SelectList(_licenceCategoryApplication.GetLicenceCategories(), "Id", "Name");
          //  Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "Fullname");

            // جستجو بر اساس مدل جستجو
            Companies = _company.Serach(searchModel) ?? new List<CompanyViewModel>();

            PopulateSelectLists();

        }

        public IActionResult OnPostBatchEdit(BatchEditCompany command)
        {
            PopulateSelectLists();

            var result = _company.BatchEdit(command);
            if (result.IsSucceeded)
            {
                TempData["SuccessMessageameEd"] = "تغییرات با موفقیت اعمال شد.";
            }
            else
            {
                TempData["ErrorMessageameEd"] = "خطایی در اعمال تغییرات رخ داد.";
            }
            return RedirectToPage("./RegisterToAccount");
        }


        private void PopulateSelectLists()
        {
            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);

            var accounts = _accountApplication.Search(new AccountSearchModel(), currentUserRole == Convert.ToInt64(RolesConst.State) ? currentUserProvinceId : (long?)null);
            AccountList = accounts.Select(accounts => new SelectListItem(accounts.Fullname, accounts.Id.ToString())).ToList();


        }






    }
}


