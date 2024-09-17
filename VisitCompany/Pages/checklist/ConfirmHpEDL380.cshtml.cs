using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using Framework.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class ConfirmHpEDL380Model : PageModel
    {
        [TempData]
        public string ErrorMessageameEd { get; set; }

        [TempData]
        public string SuccessMessageameEd { get; set; }



        public ConfirmHpEDL380Model(ICompanyApplication companyApplication, IChecklistApplication checklistApplication)
        {
            _companyApplication = companyApplication;
            _checklistApplication = checklistApplication;
        }


        private readonly ICompanyApplication _companyApplication;
        private readonly IChecklistApplication _checklistApplication;



        [BindProperty]
        public CreateHPEDL380Checklist Command { get; set; }

        public void OnGet(CreateHPEDL380Checklist command)
        {
            Command = command;
        }

        public IActionResult OnPost(CreateHPEDL380Checklist command)
        {
            // داده‌ها را در اینجا ذخیره کنید
            var operationResult = _checklistApplication.CreateHPEDL380(command);



            if (operationResult.IsSucceeded)
            {
                SuccessMessageameEd = operationResult.Message;
                var getid = operationResult.EntityId;
                _checklistApplication.EditHPEDL380(getid, command.ChecklistId);
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
