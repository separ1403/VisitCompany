using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.CompanyCategories
{
    [Authorize]
    public class EditModel : PageModel
    {
        

        [TempData]
        public string ErrorMessageameEd { get; set; }

        [TempData]
        public string SuccessMessageameEd { get; set; }

        public EditCompanyCategory Command { get; set; }

        private readonly ICompanyCategoryApplication _companyCategoryApplication;

        public EditModel(ICompanyCategoryApplication companyCategoryApplication)
        {
            _companyCategoryApplication = companyCategoryApplication;
        }

        [NeedsPermission(CompanyPermission.EditCompanyCategory)]
        public void OnGet(long id)
        {
            Command = _companyCategoryApplication.GetDetails(id);
        }

        [NeedsPermission(CompanyPermission.EditCompanyCategory)]
        public IActionResult  OnPostEdit(EditCompanyCategory command)
        {
            var operationResult = _companyCategoryApplication.Edit(command);



            if (operationResult.IsSucceeded)

                SuccessMessageameEd = operationResult.Message;

            else

                ErrorMessageameEd = operationResult.Message;

            return RedirectToPage("./Index");

        }
    }
}
