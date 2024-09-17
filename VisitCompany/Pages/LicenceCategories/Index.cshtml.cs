using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.LicenceCategories
{
    // [Authorize(Roles = RolesConst.Administrator)]//admin && content uploader
    [Authorize]
    public class IndexModel : PageModel
    {
        

        public LicenceCategorySearchModel SearchModel;
        public List<LicenceCategoryViewModel> LicenceCategories;
        private readonly ILicenceCategoryApplication _licenceCategoryApplication;

        public IndexModel(ILicenceCategoryApplication licenceCategoryApplication)
        {
            _licenceCategoryApplication = licenceCategoryApplication;
        }


        [NeedsPermission(CompanyPermission.ListLicenceCategories)]
        public void OnGet(LicenceCategorySearchModel searchModel)
        {
            LicenceCategories   = _licenceCategoryApplication.Search(searchModel);
        }
    }
}
