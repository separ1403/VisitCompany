using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using System.Text.Json;
using Framework.Application;
using Microsoft.AspNetCore.Authorization;
using System;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class ConfirmModel : PageModel
    {
        [TempData] public string ErrorMessageameEd { get; set; }

        [TempData] public string SuccessMessageameEd { get; set; }

        private readonly ICompanyApplication _companyApplication;
        private readonly IChecklistApplication _checklistApplication;

        [BindProperty] 
        public CreateGeneralChecklist Command { get; set; }

        public ConfirmModel(ICompanyApplication companyApplication, IChecklistApplication checklistApplication)
        {
            _companyApplication = companyApplication;
            _checklistApplication = checklistApplication;
        }

        public void OnGet(CreateGeneralChecklist command)
        {
            Command = command;
        }



        public IActionResult OnPost(CreateGeneralChecklist command)
        {
            // داده‌ها را در اینجا ذخیره کنید
            var operationResult = _checklistApplication.CreateGeneralChecklist(command);



            if (operationResult.IsSucceeded)
            {
                SuccessMessageameEd = operationResult.Message;
                var getid = operationResult.EntityId; // گرفتن شناسه رکورد جدید از نتیجه عملیات

                _checklistApplication.EditGeneralChecklist(getid, command.ChecklistId);
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
   

