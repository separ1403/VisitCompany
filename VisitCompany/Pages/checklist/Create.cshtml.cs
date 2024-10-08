using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.CompanyCategory;
using Framework.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class CreateModel : PageModel
    {
        [TempData] public string ErrorMessageame { get; set; }

        [TempData] public string SuccessMessageame { get; set; }

        public List<SelectListItem> AccountList = new List<SelectListItem>();

        public SelectList Companies;
        private readonly IAccountApplication _accountApplication;
        private readonly IChecklistApplication _checklistApplication;
        private readonly ICompanyApplication _companyApplication;

        public CreateModel(IAccountApplication accountApplication, IChecklistApplication checklistApplication,
            ICompanyApplication companyApplication)
        {
            _accountApplication = accountApplication;
            _checklistApplication = checklistApplication;
            _companyApplication = companyApplication;
        }


        //  public ChecklistViewModel ChecklistViewModel { get; set; }
        [BindProperty]
        public CreateChecklist Command { get; set; }

        public void OnGet()
        {
            var accounts = _accountApplication.GetAccounts();
            AccountList = accounts.Select(accounts => new SelectListItem(accounts.Fullname, accounts.Id.ToString()))
                .ToList();

            Companies = new SelectList(_companyApplication.GetCompeniesWithUsername(), "Id", "Brand");
        }

        public IActionResult OnPostCreate(CreateChecklist command)
        {
            var operationResult = _checklistApplication.Create(command);


            if (operationResult.IsSucceeded)
            {
                SuccessMessageame = operationResult.Message;
               // TempData["CommandId"] = operationResult.EntityId.ToString(); // تبدیل long به string برای ذخیره در TempData

                var getid = operationResult.EntityId; // گرفتن شناسه رکورد جدید از نتیجه عملیات
                return RedirectToPage("./ChecklistMenu", new { id = getid });
            }

            else
            {
                ErrorMessageame = operationResult.Message;
                return Page();
            }

        }




    }

}
