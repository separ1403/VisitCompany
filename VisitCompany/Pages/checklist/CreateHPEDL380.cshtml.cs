using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Infrasructure.EFCore.Migrations;
using CompanyManagement.Infrasructure.EFCore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class CreateHPEDL380Model : PageModel
    {
        public CreateHPEDL380Model(IChecklistApplication checklistApplication)
        {
            _checklistApplication = checklistApplication;
        }


        private readonly IChecklistApplication _checklistApplication;


        [BindProperty]
        public CreateHPEDL380Checklist Command { get; set; }
        [TempData] public string ErrorMessageame { get; set; }


       
        public IActionResult OnGet(long id)
        {

            var checklistId = _checklistApplication.Getdetails(id);

            if (checklistId == null)
            {
                ErrorMessageame = "چک لیست با این شناسه یافت نشد.";
                return RedirectToPage("Index"); // کاربر را به صفحه Index بازمی‌گرداند
            }


            var checklist = _checklistApplication.GetdetailsHPEDL380Checklist(checklistId.HpedlId);



            // اگر ارزیابی قبلاً تکمیل شده باشد
            if (checklist != null && checklist.IsCompleted)
            {
                ErrorMessageame = "این ارزیابی قبلاً تکمیل شده است و نمی‌توانید مجدداً آن را انجام دهید.";
                return RedirectToPage("Index"); // به صفحه Index بازمی‌گردد
            }

            Command = new CreateHPEDL380Checklist { ChecklistId = id };
            return Page(); // ادامه صفحه برای کاربر
        }

        public IActionResult OnPost(CreateHPEDL380Checklist command)
        {
            return RedirectToPage("./ConfirmHpEDL380", command);
        }
    }
}
