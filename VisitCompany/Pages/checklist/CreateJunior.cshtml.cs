using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyManagement.Application.Contract.Checklist;
using Microsoft.AspNetCore.Authorization;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Infrasructure.EFCore.Repository;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class CreateJuniorModel : PageModel
    {
        public CreateJuniorModel(IChecklistApplication checklistApplication)
        {
            _checklistApplication = checklistApplication;
        }


        private readonly IChecklistApplication _checklistApplication;

        [BindProperty]
        public CreateJuniperChecklist Command { get; set; }
        [TempData] public string ErrorMessageame { get; set; }

        public IActionResult OnGet(long id)
        {

            var checklistId = _checklistApplication.Getdetails(id);

            if (checklistId == null)
            {
                ErrorMessageame = "چک لیست با این شناسه یافت نشد.";
                return RedirectToPage("Index"); // کاربر را به صفحه Index بازمی‌گرداند
            }


            var checklist = _checklistApplication.GetdetailsJuniperChecklist(checklistId.JuniperId);



            // اگر ارزیابی قبلاً تکمیل شده باشد
            if (checklist != null && checklist.IsCompleted)
            {
                ErrorMessageame = "این ارزیابی قبلاً تکمیل شده است و نمی‌توانید مجدداً آن را انجام دهید.";
                return RedirectToPage("Index"); // به صفحه Index بازمی‌گردد
            }

            Command = new CreateJuniperChecklist { ChecklistId = id };
            return Page(); // ادامه صفحه برای کاربر

        }

        public IActionResult OnPost(CreateJuniperChecklist command)
        {
            return RedirectToPage("./ConfirmJunior", command);
        }
    }
}