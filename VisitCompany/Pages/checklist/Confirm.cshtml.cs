using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using System.Text.Json;
using Framework.Application;
using Microsoft.AspNetCore.Authorization;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class ConfirmModel : PageModel
    {
        [TempData]
        public string ErrorMessageameEd { get; set; }

        [TempData]
        public string SuccessMessageameEd { get; set; }

        private readonly ICompanyApplication _companyApplication;
        private readonly IChecklistApplication _checklistApplication;

        [BindProperty]
        public EditChecklist Command { get; set; }
        public bool IsBackFromIndex { get; set; }

        public ConfirmModel(ICompanyApplication companyApplication, IChecklistApplication checklistApplication)
        {
            _companyApplication = companyApplication;
            _checklistApplication = checklistApplication;
        }

        public void OnGet(bool isBackFromIndex = false)
        {
            IsBackFromIndex = isBackFromIndex;

            if (TempData["EditChecklist"] != null) 
            {
                Command = JsonSerializer.Deserialize<EditChecklist>(TempData["EditChecklist"].ToString()); // model ro az page creategeneralcheck migiram
                TempData.Keep("EditChecklist"); // حفظ داده‌ها برای درخواست بعدی   // baraye inke bad az yekbar estefade dada ha to tempdata
                                                // az bein miran in dastor ro neveshtam
            }
            else
            {
                Command = new EditChecklist();
            }

            var idFromSession = HttpContext.Session.GetString("ChecklistId"); // خوندن داده ای که در سشن ذخیره شده بود
            if (!string.IsNullOrEmpty(idFromSession) && Command.Id == 0)
            {
                Command.Id = long.Parse(idFromSession);
            }
        }

        public IActionResult OnPost(string action)
        {

            if (TempData["EditChecklist"] != null)
            {
                Command = JsonSerializer.Deserialize<EditChecklist>(TempData["EditChecklist"].ToString()); // estefade dobare az tempdata chon dada ha az onget be onpost nemian
                TempData.Remove("EditChecklist"); // حذف داده‌ها بعد از استفاده
            }


            if (Command.Id == 0)
            {
                var idFromSession = HttpContext.Session.GetString("ChecklistId");
                if (!string.IsNullOrEmpty(idFromSession))
                {
                    Command.Id = long.Parse(idFromSession);
                }
            }


            var operationResult = _checklistApplication.Edit(Command, "Confirm");

            if (operationResult.IsSucceeded)
                SuccessMessageameEd = operationResult.Message;
            else
                ErrorMessageameEd = operationResult.Message;



            switch (action)
            {
                case "CreateJunior":
                    return RedirectToPage("./CreateJunior", new { id = Command.Id });
                case "CreateHPEDL380":
                    return RedirectToPage("./CreateHPEDL380", new { id = Command.Id });
                case "Fortigate":
                    return RedirectToPage("./Fortigate", new { id = Command.Id });

                case "Createwin2019":
                    return RedirectToPage("./Createwin2019", new { id = Command.Id });

                default:
                    return Page();
            }
        }
    }
   
}
