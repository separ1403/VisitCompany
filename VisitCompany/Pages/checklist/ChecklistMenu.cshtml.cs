using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.checklist
{
    public class ChecklistMenuModel : PageModel
    {

        [TempData] public string ErrorMessageame { get; set; }

        [TempData] public string SuccessMessageame { get; set; }
        public void OnGet(long? id)
        {
            if (id.HasValue)
            {
                TempData["CommandId"] = id.Value.ToString(); // ذخیره `id` در TempData
            }
        }



        public IActionResult OnPostSwitch(string action)
        {
            if (TempData["CommandId"] == null)
            {
                ErrorMessageame = "Command Id is not set.";
                return Page();
            }

            long commandId = long.Parse(TempData["CommandId"].ToString()); // دریافت `id` از TempData

            switch (action)
            {
                case "CreateJunior":
                    return RedirectToPage("./CreateJunior", new { id = commandId });
                case "CreateHPEDL380":
                    return RedirectToPage("./CreateHPEDL380", new { id = commandId });
                case "CreateGeneralCheck":
                    return RedirectToPage("./CreateGeneralCheck", new { id = commandId });
                case "Createwin2019":
                    return RedirectToPage("./Createwin2019", new { id = commandId });
                default:
                    return Page();
            }
        }

    }
}
