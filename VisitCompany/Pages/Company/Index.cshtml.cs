using System.Security.Claims;
using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Application.Contract.StateCategory;
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
        public SelectList States;

        [TempData]
        public string ErrorMessageameEd { get; set; }

        [TempData]
        public string SuccessMessageameEd { get; set; }

        public List<SelectListItem> AccountList = new List<SelectListItem>();
        public BatchEditCompany Command { get; set; }
        public EditCompany CommandRasmio { get; set; }
        public List<string> Error { get; set; } = new List<string>();

        public CompanyResponse CompanyData { get; set; } // تعریف برای ارسال به ویو

        public CompanyCategorySearchModel SearchModelCategory;
        public List<CompanyCategoryViewModel> CompanyCategoriesList;

        private readonly ICompanyApplication _company;
        private readonly ICompanyCategoryApplication _companyCategoryApplication;
        private readonly ILicenceCategoryApplication _licenceCategoryApplication;
        private readonly IAccountApplication _accountApplication;
        private readonly IStatecategoryApplication _statecategoryApplication;
        private readonly ILogger<CreateModel> _logger;
        private readonly HttpClient _httpClient;

        public IndexModel(ICompanyApplication company, ICompanyCategoryApplication companyCategoryApplication, ILicenceCategoryApplication licenceCategoryApplication, IAccountApplication accountApplication, IStatecategoryApplication statecategoryApplication, ILogger<CreateModel> logger, HttpClient httpClient)
        {
            _company = company;
            _companyCategoryApplication = companyCategoryApplication;
            _licenceCategoryApplication = licenceCategoryApplication;
            _accountApplication = accountApplication;
            _statecategoryApplication = statecategoryApplication;
            _logger = logger;
            _httpClient = httpClient;
        }

      //  [NeedsPermission(CompanyPermission.ListCompanies)]
        public async Task OnGet(long id)
        {
            if (id != 0)
            {
                await OnGetUpdateRasmioAsync(id);
                Companies = _company.Serach(new CompanySearchModel());
            }
            else
            {
                PopulateSelectLists();

                CompanyCategories = new SelectList(_companyCategoryApplication.GetCompanyCategories(), "Id", "Name");
                LicenceCategories = new SelectList(_licenceCategoryApplication.GetLicenceCategories(), "Id", "Name");
                Companies = _company.Serach(new CompanySearchModel());

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
            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "Fullname");


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
            return RedirectToPage("./Index");
        }


        private void PopulateSelectLists()
        {

            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);
            States = new SelectList(_statecategoryApplication.List(), "Id", "Name");
            CompanyCategoriesList = _companyCategoryApplication.Search(SearchModelCategory) ?? new List<CompanyCategoryViewModel>();

            var accounts = _accountApplication.GetAccounts(
(currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
? currentUserProvinceId
: (long?)null
);

            Accounts = new SelectList(accounts ?? new List<AccountViewModel>(), "Id", "Fullname");
            AccountList = accounts.Select(accounts => new SelectListItem(accounts.Fullname, accounts.Id.ToString())).ToList();

        }


        public async Task<IActionResult> OnGetUpdateRasmioAsync(long id)
        {

            if (id == 0)
            {
                TempData["ErrorMessage"] = "شناسه معتبر نیست.";
                return RedirectToPage("/Index");
            }

            var result = await _company.EditRasmio(id);

            if (result.IsSucceeded)
            {
                TempData["SuccessMessage"] = result.Message;
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToPage("/Company/Index");
        }


    }
}
