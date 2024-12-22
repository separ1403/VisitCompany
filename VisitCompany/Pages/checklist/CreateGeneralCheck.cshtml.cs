using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyManagement.Application.Contract.Checklist;
using System.Text.Json;
using CompanyManagement.Domain.ChecklistAgg;
using Microsoft.AspNetCore.Authorization;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class CreateGeneralCheckModel : PageModel
    {
        public CreateGeneralCheckModel(IChecklistApplication checklistApplication)
        {
            _checklistApplication = checklistApplication;
        }


        private readonly IChecklistApplication _checklistApplication;



        [TempData] public string ErrorMessageameEd { get; set; }

        [BindProperty]
        public CreateGeneralChecklist Command { get; set; }

        public IActionResult OnGet(long id)
        {
            var checklistId = _checklistApplication.Getdetails(id);

            if (checklistId == null)
            {
                ErrorMessageameEd = "چک لیست با این شناسه یافت نشد.";
                return RedirectToPage("Index");
            }

            var generalChecklist = _checklistApplication.GetdetailsGeneralChecklist(checklistId.GeneralchecklistId);

            if (generalChecklist != null && generalChecklist.IsCompleted)
            {
                ErrorMessageameEd = "این ارزیابی قبلاً تکمیل شده است و نمی‌توانید مجدداً آن را انجام دهید.";
                return RedirectToPage("Index");
            }

            Command = new CreateGeneralChecklist { ChecklistId = id };

            // تست مقداردهی
            Console.WriteLine($"Command Name: {Command.Name}");

            return Page();
        }


        public IActionResult OnPost(CreateGeneralChecklist command)
        {
            return RedirectToPage("./Confirm", command);
        }
    }
}