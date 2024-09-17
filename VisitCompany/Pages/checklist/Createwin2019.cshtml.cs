using CompanyManagement.Application.Contract.Checklist;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.checklist
{
    public class Createwin2019Model : PageModel
    {
        [BindProperty]
        public CreateWin2019Checklist Command { get; set; }
        public void OnGet(long id)
        {
            Command = new CreateWin2019Checklist();
            Command.ChecklistId = id;
        }

        public IActionResult OnPost(CreateWin2019Checklist command)
        {
            return RedirectToPage("./ConfirmWin2019", command);
        }
    }
}
