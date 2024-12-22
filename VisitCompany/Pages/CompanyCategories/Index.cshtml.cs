using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.CompanyCategories
{
    // [Authorize(Roles = RolesConst.Administrator)]//admin && content uploader
    [Authorize]
    public class IndexModel : PageModel
    {
        public IndexModel(ICompanyCategoryApplication companyCategoryApplication, ICompanyApplication companyApplication)
        {
            _companyCategoryApplication = companyCategoryApplication;
            _companyApplication = companyApplication;
        }


        public CompanyCategorySearchModel SearchModel;
        public List<CompanyCategoryViewModel> CompanyCategories;
        private readonly ICompanyCategoryApplication _companyCategoryApplication;
        private readonly ICompanyApplication _companyApplication;

      

        [NeedsPermission(CompanyPermission.ListCompanyCategories)]
        public IActionResult OnGetDetails(int id)
        {

            if (id == 0)
                return Content("Invalid ID received");

            var Componies = _companyApplication.GetCompaniesByCategoryId(id);
            if (Componies == null)
                return Content("اطلاعات شرکت یافت نشد.");

            return Partial("_CompanyDetails", Componies);
        }


        [NeedsPermission(CompanyPermission.ListCompanyCategories)]
        public void OnGet(CompanyCategorySearchModel searchModel)
        {
            CompanyCategories = _companyCategoryApplication.Search(searchModel);
        }
    }
}
