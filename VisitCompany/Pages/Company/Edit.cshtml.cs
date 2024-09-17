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

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    [Authorize]
    public class EditModel : PageModel
    {
        public EditModel(ICompanyApplication companyApplication, ICompanyCategoryApplication companyCategoryApplication, ILicenceCategoryApplication licenceCategoryApplication, IAccountApplication accountApplication)
        {
            _companyApplication = companyApplication;
            _companyCategoryApplication = companyCategoryApplication;
            _licenceCategoryApplication = licenceCategoryApplication;
            _accountApplication = accountApplication;
        }


        [TempData]
        public string ErrorMessageameEd { get; set; }

        [TempData]
        public string SuccessMessageameEd { get; set; }

        public List<SelectListItem> Accounts = new List<SelectListItem>();
        public EditCompany Command { get; set; }
        public SelectList CompanyCategories;
        public SelectList LicenceCategories;

        private readonly ICompanyApplication _companyApplication;
        private readonly ICompanyCategoryApplication _companyCategoryApplication;
        private readonly ILicenceCategoryApplication _licenceCategoryApplication;
        private readonly IAccountApplication _accountApplication;


        [NeedsPermission(CompanyPermission.EditCompanies)]
        public void OnGet(long id)
        {
            Command = _companyApplication.Getdetails(id);

            if (Command == null)
            {
                ErrorMessageameEd = "شرکت مورد نظر یافت نشد";
                // مدیریت حالت null، مثلاً انتقال به صفحه خطا یا نمایش پیام
                return; // خروج از متد برای جلوگیری از پردازش بیشتر
            }

            CompanyCategories = new SelectList(_companyCategoryApplication.GetCompanyCategories(), "Id", "Name");
            LicenceCategories = new SelectList(_licenceCategoryApplication.GetLicenceCategories(), "Id", "Name");

            // اطمینان حاصل کنید که لیست حساب‌ها پر شده است
            var accounts = _accountApplication.GetAccounts();//کل اکانت ها رو میاره 
            Accounts = accounts.Select(account => new SelectListItem
            //کل اکانت ها رو داخل سلکت لیست آیتم نمایش میده 
            {
                Value = account.Id.ToString(),
                Text = account.Fullname,
                Selected = Command.AccountIds.Contains(account.Id) //oni ro az in account haye dakhele ( SelectListItem) entekhab mikone ke id on
                                                                   //barabar bashe ba  command ke hamon company hast va dar property AccountIds.
            }).ToList();
        }



        [NeedsPermission(CompanyPermission.EditCompanies)]
        public IActionResult OnPostEdit(EditCompany command)
        {
            if (!ModelState.IsValid)
            {
                ErrorMessageameEd = "لطفا مقادیر خواسته شده را به درستی پر نمایید";
                return Page();
            }

            var operationResult = _companyApplication.Edit(command);

            if (operationResult.IsSucceeded)
                SuccessMessageameEd = operationResult.Message;
            else
                ErrorMessageameEd = operationResult.Message;

            return RedirectToPage("./Index");
        }

    }
}
