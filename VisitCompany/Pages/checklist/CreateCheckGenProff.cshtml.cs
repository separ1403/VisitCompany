using CompanyManagement.Application.Contract.Checklist;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.checklist
{
    public class CreateCheckGenProffModel : PageModel
    {
        private readonly IChecklistApplication _checklistApplication;

        public CreateCheckGenProffModel(IChecklistApplication checklistApplication)
        {
            _checklistApplication = checklistApplication;
        }

        [BindProperty]
        public CreateCheckGenpro Command { get; set; }
        [TempData] public string ErrorMessageame { get; set; }

        public IActionResult OnGet(long id)
        {

            var checklistId = _checklistApplication.Getdetails(id);

            if (checklistId == null)
            {
                ErrorMessageame = "چک لیست با این شناسه یافت نشد.";
                return RedirectToPage("Index"); // کاربر را به صفحه Index بازمی‌گرداند
            }


            var generalproffchecklist = _checklistApplication.GetdetailsGeneralChecklistProff(checklistId.GeneralchecklistProffId);

            

 

            if (generalproffchecklist != null && generalproffchecklist.IsCompleted)
            {
                ErrorMessageame = "این ارزیابی قبلاً تکمیل شده است و نمی‌توانید مجدداً آن را انجام دهید.";
                return RedirectToPage("Index");
            }

            Command = new CreateCheckGenpro { ChecklistId = id };

            // تست مقداردهی
            Console.WriteLine($"Command Name: {Command.Name}");

            return Page();

        }

        public IActionResult OnPost(CreateCheckGenpro command)
        {
            return RedirectToPage("./ConfirmCheckGenProff", command);
        }
    }
}
