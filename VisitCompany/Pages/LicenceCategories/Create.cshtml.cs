using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

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
            // دریافت کلایم‌های موردنظر
            // دریافت نام کاربر از Claim
            var fullName = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var roleClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            var role = roleClaim?.Value; // استخراج مقدار Role

            OperationResult operationResult;


            if (ModelState.IsValid)
            {

                if (role == RolesConst.Administrator)
                {
                    command.Fullname = fullName;
                    command.Status = true;
                     operationResult = _licenceCategoryApplication.Create(command);
                }
                else
                {
                    command.Fullname = fullName;
                     command.Status = false;
                     operationResult = _licenceCategoryApplication.Create(command);
                }


                //  var operationResult = _licenceCategoryApplication.Create(command);

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
