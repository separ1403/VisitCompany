using CompanyManagement.Application.Contract.Checklist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class CreateHPEDL380Model : PageModel
    {
        [BindProperty]
        public CreateHPEDL380Checklist Command { get; set; }
        public void OnGet(long id)
        {
            Command = new CreateHPEDL380Checklist();
            Command.ChecklistId = id;
        }

        public IActionResult OnPost(CreateHPEDL380Checklist command)
        {
            return RedirectToPage("./ConfirmHpEDL380", command);
        }
    }
}
