using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.StateCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.StateCategories
{
  //  [Authorize]
    public class CreateModel : PageModel
    {
        [TempData]
        public string ErrorMessageame { get; set; }

        [TempData]
        public string SuccessMessageame { get; set; }



        public CreateStateCategory Command { get; set; }

        private readonly IStatecategoryApplication _stateCategoryApplication;

        public CreateModel(IStatecategoryApplication stateCategoryApplication)
        {
            _stateCategoryApplication = stateCategoryApplication;
        }

       // [NeedsPermission(CompanyPermission.CreateStateCategory)]
        public void OnGet()
        {

        }

      //  [NeedsPermission(CompanyPermission.CreateStateCategory)]
        public IActionResult OnPostCreate(CreateStateCategory command)
        {
            if (ModelState.IsValid)
            {
                var operationResult = _stateCategoryApplication.Create(command);

                if (operationResult.IsSucceeded)
                {
                    SuccessMessageame = operationResult.Message;
                    // بازگشت به صفحه Create پس از موفقیت
                    return RedirectToPage("./Create");
                }
                else
                {
                    ErrorMessageame = operationResult.Message;
                }
            }
            else
            {
                ErrorMessageame = "لطفا مقادیر خواسته شده را به درستی پر نمایید";
            }

            // بازگشت به صفحه فعلی در صورت وجود خطا
            return Page();
        }


    }
}
