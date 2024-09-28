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



        [TempData] public string ErrorMessageame { get; set; }


        [BindProperty]
        public CreateGeneralChecklist Command { get; set; }
        public IActionResult OnGet(long id)
        {
            // دریافت شناسه چک لیست و بررسی وضعیت آن
            var checklistId = _checklistApplication.Getdetails(id);

            if (checklistId == null)
            {
                ErrorMessageame = "چک لیست با این شناسه یافت نشد.";
                return RedirectToPage("Index"); // کاربر را به صفحه Index بازمی‌گرداند
            }


            var generalChecklist = _checklistApplication.GetdetailsGeneralChecklist(checklistId.GeneralchecklistId);

            // اگر ارزیابی قبلاً تکمیل شده باشد
            if (generalChecklist != null && generalChecklist.IsCompleted)
            {
                ErrorMessageame = "این ارزیابی قبلاً تکمیل شده است و نمی‌توانید مجدداً آن را انجام دهید.";
                return RedirectToPage("Index"); // به صفحه Index بازمی‌گردد
            }

            Command = new CreateGeneralChecklist { ChecklistId = id }; //{ ChecklistId = id } yani command.checklistId = id;
            return Page(); // ادامه صفحه برای کاربر
        }

        public IActionResult OnPost(CreateGeneralChecklist command)
        {
            return RedirectToPage("./Confirm", command);
        }
    }
}