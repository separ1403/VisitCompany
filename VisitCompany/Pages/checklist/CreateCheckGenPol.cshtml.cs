using CompanyManagement.Application.Contract.Checklist;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.checklist
{
    public class CreateCheckGenPolModel : PageModel
    {
        private readonly IChecklistApplication _checklistApplication;

        public CreateCheckGenPolModel(IChecklistApplication checklistApplication)
        {
            _checklistApplication = checklistApplication;
        }

        [BindProperty]
        public CreateCheckGenPol Command { get; set; }
        [TempData] 
        public string ErrorMessageame { get; set; }

        public IActionResult OnGet(long id)
        {

            var checklistId = _checklistApplication.Getdetails(id);

            if (checklistId == null)
            {
                ErrorMessageame = "چک لیست با این شناسه یافت نشد.";
                return RedirectToPage("Index"); // کاربر را به صفحه Index بازمی‌گرداند
            }


            var generalpolchecklist = _checklistApplication.GetdetailsGeneralChecklistPol(checklistId.GeneralchecklistPolId);





            if (generalpolchecklist != null && generalpolchecklist.IsCompleted)
            {
                ErrorMessageame = "این ارزیابی قبلاً تکمیل شده است و نمی‌توانید مجدداً آن را انجام دهید.";
                return RedirectToPage("Index");
            }

            Command = new CreateCheckGenPol { ChecklistId = id };

            // تست مقداردهی
            Console.WriteLine($"Command Name: {Command.Name}");

            return Page();

        }

        public IActionResult OnPost(CreateCheckGenPol command)
        {
            return RedirectToPage("./ConfirmCheckGenPol", command);
        }
    }
}
