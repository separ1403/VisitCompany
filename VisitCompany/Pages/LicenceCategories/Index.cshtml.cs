using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisitCompany.Pages.LicenceCategories
{
    // [Authorize(Roles = RolesConst.Administrator)]//admin && content uploader
    [Authorize]
    public class IndexModel : PageModel
    {
        public IndexModel(ILicenceCategoryApplication licenceCategoryApplication, ICompanyApplication companyApplication, ICompanyCategoryApplication companyCategoryApplication)
        {
            _licenceCategoryApplication = licenceCategoryApplication;
            _companyApplication = companyApplication;
            _companyCategoryApplication = companyCategoryApplication;
        }


        public List<CompanyViewModel> Companies;

        public List<LicenceCategoryViewModel> LicenceCategorieList;
        public List<LicenceCategoryViewModel> LicenceCategorieListDisable;

        public SelectList LicenceCategories { get; set; }
        public SelectList CompanyCategories { get; set; }

        public CompanySearchModel SearchModel { get; set; }
        public LicenceCategorySearchModel SearchModelLicence { get; set; }




        //  public List<LicenceCategoryViewModel> LicenceCategories;

        private readonly ILicenceCategoryApplication _licenceCategoryApplication;
        private readonly ICompanyApplication _companyApplication;
        private readonly ICompanyCategoryApplication _companyCategoryApplication;





        [NeedsPermission(CompanyPermission.ListLicenceCategories)]
        public void OnGet(CompanySearchModel searchModel , LicenceCategorySearchModel searchModelLicence)
        {
            LicenceCategories = new SelectList(_licenceCategoryApplication.GetLicenceCategories(), "Id", "Name");
            CompanyCategories = new SelectList(_companyCategoryApplication.GetCompanyCategories(), "Id", "Name");

            //     LicenceCategories   = _licenceCategoryApplication.Search(searchModel);
            Companies = _companyApplication.Serach(searchModel) ?? new List<CompanyViewModel>();
            LicenceCategorieList = _licenceCategoryApplication.Search(searchModelLicence);
            LicenceCategorieListDisable = _licenceCategoryApplication.SearchDisable(searchModelLicence);

        }

        public IActionResult OnPostDisableLicence(long id)
        {
            var result = _licenceCategoryApplication.DisableLicence(id); // فراخوانی متد غیرفعال کردن

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


        public IActionResult OnPostActivateleLicence(long id)
        {
            var result = _licenceCategoryApplication.EnableLicence(id); // فراخوانی متد فعال کردن

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


        [NeedsPermission(CompanyPermission.ListCompanyCategories)]  // این عوض بشه
        public IActionResult OnGetDetails(int id)
        {

            if (id == 0)
                return Content("Invalid ID received");

            var Componies = _companyApplication.GetCompaniesByLicenceId(id);
            if (Componies == null)
                return Content("اطلاعات شرکت یافت نشد.");

            return Partial("_CompanyDetails", Componies);
        }
    }
}
