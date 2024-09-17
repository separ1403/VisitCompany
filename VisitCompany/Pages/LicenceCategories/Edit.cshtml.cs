using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.LicenceCategories;
     [Authorize]
      public class EditModel : PageModel
     {
        

        [TempData]
        public string ErrorMessageameEd { get; set; }

        [TempData]
        public string SuccessMessageameEd { get; set; }

        public EditLicenceCategory Command { get; set; }

        private readonly ILicenceCategoryApplication _licenceCategoryApplication;

        public EditModel(ILicenceCategoryApplication licenceCategoryApplication)
        {
        _licenceCategoryApplication = licenceCategoryApplication;
        }

        [NeedsPermission(CompanyPermission.EditLicenceCategories)]
        public void OnGet(long id)
        {
            Command = _licenceCategoryApplication.GetDetails(id);
        }

        [NeedsPermission(CompanyPermission.EditLicenceCategories)]
         public IActionResult  OnPostEdit(EditLicenceCategory command)
        {
            var operationResult = _licenceCategoryApplication.Edit(command);



            if (operationResult.IsSucceeded)

                SuccessMessageameEd = operationResult.Message;

            else

                ErrorMessageameEd = operationResult.Message;

            return RedirectToPage("./Index");

        }
    }
