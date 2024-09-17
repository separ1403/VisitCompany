using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyManagement.Application.Contract.Checklist;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class CreateGeneralCheckModel : PageModel
    {
        private readonly IChecklistApplication _checklistApplication;

        public CreateGeneralCheckModel(IChecklistApplication checklistApplication)
        {
            _checklistApplication = checklistApplication;
        }

        [BindProperty]
        public EditChecklist Command { get; set; }

        public void OnGet(long id)
        {
            Command = _checklistApplication.Getdetails(id);
        }

        public IActionResult OnPost(EditChecklist command)
        {
            HttpContext.Session.SetString("ChecklistId", command.Id.ToString()); // ذخیره کردن id در Session  ---> inja set karde

            TempData["EditChecklist"] = JsonSerializer.Serialize(command); // ذخیره کردن اطلاعات در TempData  // baraye in bod ke nakhastam to url dadahe dide beshan 
            // hala in dada ha ro to page confirm estefade konam

            return RedirectToPage("./Confirm");

        }
    }
}