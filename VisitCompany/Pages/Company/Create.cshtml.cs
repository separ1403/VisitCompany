using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisitCompany.Pages.Company
{
    [Authorize]
    public class CreateModel : PageModel
    {
        public CreateModel(ICompanyCategoryApplication companyCategoryApplication, ICompanyApplication companyApplication, ILicenceCategoryApplication licenceApplication, IAccountApplication accountApplication)
        {
            _companyCategoryApplication = companyCategoryApplication;
            _companyApplication = companyApplication;
            _licenceApplication = licenceApplication;
            _accountApplication = accountApplication;
        }
        
        [TempData]
        public string ErrorMessageame { get; set; }

        [TempData]
        public string SuccessMessageame { get; set; }


        public List<SelectListItem> AccountList = new List<SelectListItem>();
        public SelectList CompanyCategories;
        //  public SelectList LicenceCategories;
        public List<SelectListItem> LicenceCategories = new List<SelectListItem>();

        private readonly ICompanyCategoryApplication _companyCategoryApplication;
        private readonly ICompanyApplication _companyApplication;
        private readonly ILicenceCategoryApplication _licenceApplication;
        private readonly IAccountApplication _accountApplication;


       

        public CreateCompany Command { get; set; }

        [NeedsPermission(CompanyPermission.CreateCompanies)]
        public void OnGet()
        {
            PopulateSelectLists();
            // برای این است که بعد از اجرای اول مقادیر سلکت لیست ها خالی میشدند
        }
        [NeedsPermission(CompanyPermission.CreateCompanies)]
        public IActionResult OnPostCreate(CreateCompany command)
        {
            if (!ModelState.IsValid)
            {
                ErrorMessageame = "لطفا مقادیر خواسته شده را به درستی پر نمایید";
                PopulateSelectLists(); // مقداردهی مجدد SelectList ها
                return Page();
            }

            if (string.IsNullOrWhiteSpace(command.CompanyName) || string.IsNullOrWhiteSpace(command.Brand))
            {
                ErrorMessageame = "نام یا برند شرکت نباید خالی باشد";
                PopulateSelectLists(); // مقداردهی مجدد SelectList ها
                return Page();
            }

            var operationResult = _companyApplication.Create(command);

            if (operationResult.IsSucceeded)
            {
                SuccessMessageame = operationResult.Message;
                return RedirectToPage("./Create");
            }
            else
            {
                ErrorMessageame = operationResult.Message;
            }

            PopulateSelectLists(); // مقداردهی مجدد SelectList ها
            return Page();
        }


        private void PopulateSelectLists()
        {
            CompanyCategories = new SelectList(_companyCategoryApplication.GetCompanyCategories(), "Id", "Name");
          //  LicenceCategories = new SelectList(_licenceApplication.GetLicenceCategories(), "Id", "Name");
            var accounts = _accountApplication.GetAccounts();
            AccountList = accounts.Select(accounts => new SelectListItem(accounts.Fullname, accounts.Id.ToString())).ToList();
           
            var licence = _licenceApplication.GetLicenceCategories();
            LicenceCategories = licence.Select(licence => new SelectListItem(licence.Name, licence.Id.ToString())).ToList();

        }




    }
}
