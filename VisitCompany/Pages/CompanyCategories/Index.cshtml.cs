using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.CompanyCategories
{
    // [Authorize(Roles = RolesConst.Administrator)]//admin && content uploader
    [Authorize]
    public class IndexModel : PageModel
    {
        

        public CompanyCategorySearchModel SearchModel;
        public List<CompanyCategoryViewModel> CompanyCategories;
        private readonly ICompanyCategoryApplication _companyCategoryApplication;

        public IndexModel(ICompanyCategoryApplication companyCategoryApplication)
        {
            _companyCategoryApplication = companyCategoryApplication;
        }


        [NeedsPermission(CompanyPermission.ListCompanyCategories)]
        public void OnGet(CompanyCategorySearchModel searchModel)
        {
            CompanyCategories = _companyCategoryApplication.Search(searchModel);
        }
    }
}
