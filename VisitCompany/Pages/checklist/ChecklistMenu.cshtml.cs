using CompanyManagement.Application.Contract.Checklist;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages.checklist
{
    public class ChecklistMenuModel : PageModel
    {

        [TempData] public string ErrorMessageame { get; set; }

        [TempData] public string SuccessMessageame { get; set; }
       public IActionResult OnGet(long? id)
{
    //if (id == null)
    //{
    //    return RedirectToPage("Create");
    //}

    if (id.HasValue)
    {
        TempData["CommandId"] = id.Value.ToString(); // ذخیره `id` در TempData
    }

    return Page();
}




        public IActionResult OnPostSwitch(string action)
        {
            if (TempData["CommandId"] == null)
            {
                ErrorMessageame = "جهت ایجاد چک لیست ابتدا می بایست این صفحه را تکمیل نمایید";
                return RedirectToPage("Create");
            }

            long commandId = long.Parse(TempData["CommandId"].ToString()); // دریافت `id` از TempData
            TempData.Remove("CommandId"); // حذف مقدار از TempData

            switch (action)
            {
                case "CreateJunior":
                    var redirectPage = RedirectToPage("./CreateJunior", new { id = commandId });
                    commandId = 0; // خالی کردن مقدار commandId
                    return redirectPage;
                case "CreateHPEDL380":
                    redirectPage = RedirectToPage("./CreateHPEDL380", new { id = commandId });
                    commandId = 0;
                    return redirectPage;
                case "CreateGeneralCheck":
                    redirectPage = RedirectToPage("./CreateGeneralCheck", new { id = commandId });
                    commandId = 0;
                    return redirectPage;

                    
                case "CreateCheckGenProff":
                    redirectPage = RedirectToPage("./CreateCheckGenProff", new { id = commandId });
                    commandId = 0;
                    return redirectPage;

                case "CreateCheckGenPol":
                    redirectPage = RedirectToPage("./CreateCheckGenPol", new { id = commandId });
                    commandId = 0;
                    return redirectPage;

                case "Createwin2019":
                    redirectPage = RedirectToPage("./Createwin2019", new { id = commandId });
                    commandId = 0;
                    return redirectPage;
                default:
                    commandId = 0;
                    return Page();
            }
        }

    }
}
