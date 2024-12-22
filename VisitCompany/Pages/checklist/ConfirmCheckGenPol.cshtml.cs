using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.checklist
{
    public class ConfirmCheckGenPolModel : PageModel
    {
        [TempData]
        public string ErrorMessageameEd { get; set; }

        [TempData]
        public string SuccessMessageameEd { get; set; }

        private readonly ICompanyApplication _companyApplication;
        private readonly IChecklistApplication _checklistApplication;

        public ConfirmCheckGenPolModel(ICompanyApplication companyApplication, IChecklistApplication checklistApplication)
        {
            _companyApplication = companyApplication;
            _checklistApplication = checklistApplication;
        }


        [BindProperty]
        public CreateCheckGenPol Command { get; set; }

        public void OnGet(CreateCheckGenPol command)
        {
            Command = command;
        }

        public IActionResult OnPost(CreateCheckGenPol command)
        {
            // داده‌ها را در اینجا ذخیره کنید
            var operationResult = _checklistApplication.CreateGeneralChecklistPol(command);

            if (operationResult.IsSucceeded)
            {
                SuccessMessageameEd = operationResult.Message;
                var getid = operationResult.EntityId;
                _checklistApplication.EditGeneralChecklistPol(getid, command.ChecklistId);
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
