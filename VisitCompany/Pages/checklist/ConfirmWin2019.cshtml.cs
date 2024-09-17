using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class ConfirmWin2019Model : PageModel
    {
        [TempData]
        public string ErrorMessageameEd { get; set; }

        [TempData]
        public string SuccessMessageameEd { get; set; }



        public ConfirmWin2019Model(ICompanyApplication companyApplication, IChecklistApplication checklistApplication)
        {
            _companyApplication = companyApplication;
            _checklistApplication = checklistApplication;
        }


        private readonly ICompanyApplication _companyApplication;
        private readonly IChecklistApplication _checklistApplication;



        [BindProperty]
        public CreateWin2019Checklist Command { get; set; }

        public void OnGet(CreateWin2019Checklist command)
        {
            Command = command;
        }

        public IActionResult OnPost(CreateWin2019Checklist command)
        {
            // داده‌ها را در اینجا ذخیره کنید
            var operationResult = _checklistApplication.CreateWin2019(command);



            if (operationResult.IsSucceeded)
            {
                SuccessMessageameEd = operationResult.Message;
                var getid = operationResult.EntityId; // گرفتن شناسه رکورد جدید از نتیجه عملیات

                _checklistApplication.EditWin2019(getid, command.ChecklistId);
                return RedirectToPage("./index");

            }



            else
            {
                ErrorMessageameEd = operationResult.Message;
                return Page();

            }



        }
    }
}
