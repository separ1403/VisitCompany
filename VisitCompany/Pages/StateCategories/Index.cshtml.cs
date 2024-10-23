using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.StateCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.StateCategories
{
    [Authorize]
    public class IndexModel : PageModel
    {


        public StatecategorySearchModel SearchModel;
        public List<StateCategoryViewModel> StateCategories;
        private readonly IStatecategoryApplication _stateCategoryApplication;

        public IndexModel(IStatecategoryApplication stateCategoryApplication)
        {
            _stateCategoryApplication = stateCategoryApplication;
        }

        [NeedsPermission(CompanyPermission.ListStateCategories)]
        public void OnGet(StatecategorySearchModel searchModel)
        {
            StateCategories = _stateCategoryApplication.Search(searchModel);
        }
    }
}
