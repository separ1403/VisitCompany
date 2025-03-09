using AccountManagement.Application.Contracts.Account;
using Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Pages
{
    public class AccountModel : PageModel
    {

        [TempData]
        public string LoginMessage { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }

        private readonly IAccountApplication _accountApplication;

        //[BindProperty]
        //public RegisterAccount RegisterAccount { get; set; } // افزودن مدل ثبت ‌نام

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
            TempData["LoginMessage"] = null;
        }

        public IActionResult OnPostLogin(Login command)
        {
            var operationResult = _accountApplication.Login(command);

            if (operationResult.IsSucceeded)
            {
                HttpContext.Session.SetString("CommandUsername", command.Username);
                HttpContext.Session.SetString("CommandMobile", command.Mobile);
        
                return RedirectToPage("./EnterCode", new { mobile = command.Mobile });
            }
    
            // وقتی خطا هست، JSON با کد 400 برگردون
            return new JsonResult(new { success = false, message = operationResult.Message })
            {
                StatusCode = 400 // Bad Request
            };
        }

        public IActionResult OnGetLogout()
        {

            _accountApplication.Logout();
            return RedirectToPage("./Index");
        }

        //public IActionResult OnPostRegister()
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        RegisterMessage = "لطفاً تمامی فیلدها را به درستی پر کنید.";
        //        return Page();
        //    }
        //    var operationResult = _accountApplication.Register(RegisterAccount);


        //    if (operationResult.IsSucceeded)
        //    {
        //        return RedirectToPage("/index");

        //    }
            


        //    RegisterMessage = operationResult.Message;

        //    return Page();
        //}
    }
}
