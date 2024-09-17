using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using Framework.Application;
using Microsoft.AspNetCore.Authorization;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class ConfirmJuniorModel : PageModel
    {

        [TempData]
        public string ErrorMessageameEd { get; set; }

        [TempData]
        public string SuccessMessageameEd { get; set; }



        public ConfirmJuniorModel(ICompanyApplication companyApplication, IChecklistApplication checklistApplication)
        {
            _companyApplication = companyApplication;
            _checklistApplication = checklistApplication;
        }
        

        private readonly ICompanyApplication _companyApplication;
        private readonly IChecklistApplication _checklistApplication;



        [BindProperty]
        public CreateJuniperChecklist Command { get; set; }

        public void OnGet(CreateJuniperChecklist command)
        {
            Command = command;
        }

        public IActionResult OnPost( CreateJuniperChecklist command)
        {
            // داده‌ها را در اینجا ذخیره کنید
            var operationResult = _checklistApplication.CreateJuniper(command);



            if (operationResult.IsSucceeded)
            {
                SuccessMessageameEd = operationResult.Message;
                var getid = operationResult.EntityId; // گرفتن شناسه رکورد جدید از نتیجه عملیات

                _checklistApplication.EditJunior(getid,command.ChecklistId);
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