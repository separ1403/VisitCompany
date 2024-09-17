using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.LicenceCategories
{
    [Authorize]
    public class CreateModel : PageModel
    {
       

        [TempData]
        public string ErrorMessageame { get; set; }

        [TempData]
        public string SuccessMessageame { get; set; }
        
      

        public CreateLicenceCategory Command { get; set; }

        private readonly ILicenceCategoryApplication _licenceCategoryApplication;

        public CreateModel(ILicenceCategoryApplication licenceCategoryApplication)
        {
            _licenceCategoryApplication = licenceCategoryApplication;
        }
        [NeedsPermission(CompanyPermission.CreateLicenceCategories)]
        public void OnGet()
        {

        }

        [NeedsPermission(CompanyPermission.CreateLicenceCategories)]
        public IActionResult OnPostCreate(CreateLicenceCategory command)
        {
            if (ModelState.IsValid)
            {
                var operationResult = _licenceCategoryApplication.Create(command);

                if (operationResult.IsSucceeded)
                {
                    SuccessMessageame = operationResult.Message;
                    // بازگشت به همان صفحه پس از موفقیت
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

            // در صورت وجود خطا، دوباره همین صفحه را نمایش می‌دهد
            return Page();
        }


    }
}
