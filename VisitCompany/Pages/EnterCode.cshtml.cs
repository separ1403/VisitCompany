using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Framework.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace VisitCompany.Pages
{
    public class EnterCodeModel : PageModel
    {
        public EnterCodeModel(IAccountApplication accountApplication, IHttpContextAccessor httpContextAccessor, IAuthHelper authHelper, IRoleAplication roleAplication)
        {
            _accountApplication = accountApplication;
            _httpContextAccessor = httpContextAccessor;
            _authHelper = authHelper;
            _roleAplication = roleAplication;
        }


        private readonly IAccountApplication _accountApplication;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleAplication _roleAplication;

        [BindProperty]
        public string Code { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public void OnGet(string mobile)
        {
            ViewData["Mobile"] = mobile;
            TempData["ErrorMessage"] = null; // پاک کردن پیام خطا در بارگذاری اولیه صفحه

        }

        public IActionResult OnPostValidateCode()
        {
            var mobile = HttpContext.Session.GetString("CommandMobile");
            var accountViewModel = _accountApplication.GetByMobile(mobile);
            var permissions = _roleAplication.GetPermissions(accountViewModel.RoleId);

            if (accountViewModel == null || accountViewModel.CodeValidateMobile != Code)
            {
                TempData["ErrorMessage"] = "کد فعالسازی نادرست است.";
                return Page();
            }

            // تایید کد موفقیت‌آمیز است، کاربر را لاگین کنید
            var authViewModel = new AuthViewModel(accountViewModel.Id, accountViewModel.RoleId, accountViewModel.Fullname, accountViewModel.UserName, accountViewModel.Mobile, permissions);

            _httpContextAccessor.HttpContext.Session.SetString("CommandId", accountViewModel.Id.ToString());
            _authHelper.Signin(authViewModel);

            // فرض بر این است که LastLoginCal و SaveChanges در لایه Application وجود دارد و پیاده‌سازی شده است
            _accountApplication.UpdateLastLogin(accountViewModel.Id);

            return RedirectToPage("UserProfile");
        }
    }
}
