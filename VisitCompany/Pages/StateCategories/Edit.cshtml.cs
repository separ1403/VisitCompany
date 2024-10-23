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
    public class EditModel : PageModel
    {


        [TempData]
        public string ErrorMessageameEd { get; set; }

        [TempData]
        public string SuccessMessageameEd { get; set; }

        public EditStateCategory Command { get; set; }

        private readonly IStatecategoryApplication _stateCategoryApplication;

        public EditModel(IStatecategoryApplication stateCategoryApplication)
        {
            _stateCategoryApplication = stateCategoryApplication;
        }

        [NeedsPermission(CompanyPermission.EditCompanyCategory)]
        public void OnGet(long id)
        {
            Command = _stateCategoryApplication.GetDetails(id);
        }

        [NeedsPermission(CompanyPermission.EditStateCategory)]
        public IActionResult OnPostEdit(EditStateCategory command)
        {
            var operationResult = _stateCategoryApplication.Edit(command);



            if (operationResult.IsSucceeded)

                SuccessMessageameEd = operationResult.Message;

            else

                ErrorMessageameEd = operationResult.Message;

            return RedirectToPage("./Index");

        }
    }
}
