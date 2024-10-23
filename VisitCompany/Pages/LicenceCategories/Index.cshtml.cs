using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
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
        public SelectList LicenceCategories { get; set; }
        public SelectList CompanyCategories { get; set; }

        public CompanySearchModel SearchModel { get; set; }



      //  public List<LicenceCategoryViewModel> LicenceCategories;

        private readonly ILicenceCategoryApplication _licenceCategoryApplication;
        private readonly ICompanyApplication _companyApplication;
        private readonly ICompanyCategoryApplication _companyCategoryApplication;





        [NeedsPermission(CompanyPermission.ListLicenceCategories)]
        public void OnGet(CompanySearchModel searchModel)
        {
            LicenceCategories = new SelectList(_licenceCategoryApplication.GetLicenceCategories(), "Id", "Name");
            CompanyCategories = new SelectList(_companyCategoryApplication.GetCompanyCategories(), "Id", "Name");

            //     LicenceCategories   = _licenceCategoryApplication.Search(searchModel);
            Companies = _companyApplication.Serach(searchModel) ?? new List<CompanyViewModel>();

        }
    }
}
