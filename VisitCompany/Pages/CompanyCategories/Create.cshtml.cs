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
    public class CreateModel : PageModel
    {
       

        [TempData]
        public string ErrorMessageame { get; set; }

        [TempData]
        public string SuccessMessageame { get; set; }
        
      

        public CreateCompanyCategory Command { get; set; }

        private readonly ICompanyCategoryApplication _companyCategoryApplication;

        public CreateModel(ICompanyCategoryApplication companyCategoryApplication)
        {
            _companyCategoryApplication = companyCategoryApplication;
        }

        [NeedsPermission(CompanyPermission.CreateCompanyCategory)]
        public void OnGet()
        {

        }

        [NeedsPermission(CompanyPermission.CreateCompanyCategory)]
        public IActionResult OnPostCreate(CreateCompanyCategory command)
        {
            if (ModelState.IsValid)
            {
                var operationResult = _companyCategoryApplication.Create(command);

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
