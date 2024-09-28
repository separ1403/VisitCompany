using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Infrasructure.EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.checklist
{
    public class Createwin2019Model : PageModel
    {

        public Createwin2019Model(IChecklistApplication checklistApplication)
        {
            _checklistApplication = checklistApplication;
        }


        private readonly IChecklistApplication _checklistApplication;


        [BindProperty]
        public CreateWin2019Checklist Command { get; set; }

        [TempData] public string ErrorMessageame { get; set; }

        public IActionResult OnGet(long id)
        {

            var checklistId = _checklistApplication.Getdetails(id);

            if (checklistId == null)
            {
                ErrorMessageame = "چک لیست با این شناسه یافت نشد.";
                return RedirectToPage("Index"); // کاربر را به صفحه Index بازمی‌گرداند
            }


            var checklist = _checklistApplication.GetdetailsWin2019Checklist(checklistId.Win2019Id);



            // اگر ارزیابی قبلاً تکمیل شده باشد
            if (checklist != null && checklist.IsCompleted)
            {
                ErrorMessageame = "این ارزیابی قبلاً تکمیل شده است و نمی‌توانید مجدداً آن را انجام دهید.";
                return RedirectToPage("Index"); // به صفحه Index بازمی‌گردد
            }

            Command = new CreateWin2019Checklist { ChecklistId = id };
            return Page(); // ادامه صفحه برای کاربر

        }

        public IActionResult OnPost(CreateWin2019Checklist command)
        {
            return RedirectToPage("./ConfirmWin2019", command);
        }
    }
}
