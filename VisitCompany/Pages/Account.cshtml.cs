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

        

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
          //  TempData["LoginMessage"] = null;
            TempData.Remove("LoginMessage"); // برای بهینه سازی از این  کد جای بالایی استفاده شد
        }

        public IActionResult OnPostLogin(Login command)
        {
            var operationResult = _accountApplication.Login(command);

            if (operationResult.IsSucceeded)
            {
                HttpContext.Session.SetString("CommandUsername", command.Username);// ذخیره کردن id در Session  ---> inja set karde
                HttpContext.Session.SetString("CommandMobile", command.Mobile);

                return RedirectToPage("./EnterCode");

               
            }
            
            LoginMessage = operationResult.Message;
            return Page();
        }


        public IActionResult OnGetLogout()
        {

            _accountApplication.Logout();
            return RedirectToPage("./Index");
        }

    }
}
