using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Infrastructure.Configuration.Permission;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisitCompany.Areas.Administration.Pages.Accounts.Role
{
   [Authorize]
    public class CreateModel : PageModel
    {
        [TempData]
        public string ErrorMessageame { get; set; }

        [TempData]
        public string SuccessMessageame { get; set; }



        public CreateRole Command { get; set; }


        private readonly IRoleAplication _roleAplication;

        public CreateModel(IRoleAplication roleAplication)
        {

            _roleAplication = roleAplication;
        }
        [NeedsPermission(CompanyPermission.CreateRoles)]
        public void OnGet()
        {

        }

        [NeedsPermission(CompanyPermission.CreateRoles)]
        public IActionResult OnPostCreate(CreateRole command)

        {


            var operationResult = _roleAplication.Create(command);



            if (operationResult.IsSucceeded)
            {
                SuccessMessageame = operationResult.Message;
                return RedirectToPage("./Create");  // به خاطر اینکه لینک زیر به وجود نیاید بعد از اولین بار اجرا
                //https://localhost:7268/Administration/Accounts/Role/Create?handler=Create
            }


            else
            {
                ErrorMessageame = operationResult.Message;
                return Page(); // در صورت وجود خطا، صفحه جاری را بازگردانید تا خطا نمایش داده شود.
            }
        }





    }
}
