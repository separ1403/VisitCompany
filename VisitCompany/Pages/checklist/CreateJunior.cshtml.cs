using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyManagement.Application.Contract.Checklist;
using Microsoft.AspNetCore.Authorization;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class CreateJuniorModel : PageModel
    {
        [BindProperty]
        public CreateJuniperChecklist Command { get; set; }

        public void OnGet(long id)
        {
            Command = new CreateJuniperChecklist();
            Command.ChecklistId = id;
        }

        public IActionResult OnPost(CreateJuniperChecklist command)
        {
            return RedirectToPage("./ConfirmJunior", command);
        }
    }
}