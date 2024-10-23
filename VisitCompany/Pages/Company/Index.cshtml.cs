using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisitCompany.Pages.Company
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public SelectList Accounts { get; set; }
        public CompanySearchModel SearchModel { get; set; }
        public List<CompanyViewModel> Companies { get; set; }
        public SelectList CompanyCategories { get; set; }
        public SelectList LicenceCategories { get; set; }

        private readonly ICompanyApplication _company;
        private readonly ICompanyCategoryApplication _companyCategoryApplication;
        private readonly ILicenceCategoryApplication _licenceCategoryApplication;
        private readonly IAccountApplication _accountApplication;

        public IndexModel(
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

        [NeedsPermission(CompanyPermission.ListCompanies)]
        public void OnGet()
        {
            // مقداردهی اولیه لیست‌ها برای نمایش در dropdown ها
            CompanyCategories = new SelectList(_companyCategoryApplication.GetCompanyCategories(), "Id", "Name");
            LicenceCategories = new SelectList(_licenceCategoryApplication.GetLicenceCategories(), "Id", "Name");
            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "Fullname");
            Companies = _company.Serach(new CompanySearchModel()); // اگر متد Serach بدون فیلتر تمام رکوردها را برگرداند

            // من اینکار رو کردم یعنی هم تو اینجا و هم تو آن پست نوشتم چرا؟
            // چون تو اینجا گذاشتم که هنگامی که صفحه برای بار اول لود میشه من تمام رکوردها رو ببینم
            // هم تو پست نوشتم چونکه میخواستم وقتی جستجو انجام بدم تو یو آر ال مقادیر جستجو ظاهر نشه


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
            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "Fullname");

            // جستجو بر اساس مدل جستجو
            Companies = _company.Serach(searchModel) ?? new List<CompanyViewModel>();
        }
    }
}
