using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.StateCategory;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace VisitCompany.Pages.checklist
{
    [Authorize]
    public class CreateModel : PageModel
    {
        [TempData] public string ErrorMessageame { get; set; }

        [TempData] public string SuccessMessageame { get; set; }

        public List<SelectListItem> AccountList = new List<SelectListItem>();

        public SelectList Companies;
        public List<CompanyViewModel> Companiess { get; set; }

        public string StateCategoryName { get; set; }

        private readonly IAccountApplication _accountApplication;
        private readonly IChecklistApplication _checklistApplication;
        private readonly ICompanyApplication _companyApplication;
        private readonly IStatecategoryApplication _statecategoryApplication;

        public CreateModel(IAccountApplication accountApplication, IChecklistApplication checklistApplication, ICompanyApplication companyApplication, IStatecategoryApplication statecategoryApplication)
        {
            _accountApplication = accountApplication;
            _checklistApplication = checklistApplication;
            _companyApplication = companyApplication;
            _statecategoryApplication = statecategoryApplication;
        }




        //  public ChecklistViewModel ChecklistViewModel { get; set; }
        [BindProperty]
        public CreateChecklist Command { get; set; }

        public void OnGet()
        {
            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);
            //var stateCategory = _statecategoryApplication.GetById(currentUserProvinceId);
            //if (stateCategory != null)
            //{
            //    StateCategoryName = stateCategory.Name;
            //}

            var accounts = _accountApplication.Search(new AccountSearchModel(),(currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
            ? currentUserProvinceId
                            : (long?)null);//

            AccountList = accounts.Select(accounts => new SelectListItem(accounts.Fullname, accounts.Id.ToString())).ToList();


            if (currentUserRole == Convert.ToInt64(RolesConst.Administrator)) // اگر نقش ادمین باشد
            {

                Companiess = _companyApplication.GetCompenies(); // تمام شرکت‌ها
            }

            else
            {
                Companiess = _companyApplication.Serach(
                new CompanySearchModel(),
                (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
               ? currentUserProvinceId
                               : (long?)null);//
            }


            Companies = new SelectList(Companiess ?? new List<CompanyViewModel>(), "Id", "Brand");
        }

        public IActionResult OnPostCreate(CreateChecklist command)
        {


            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);

            command.StateCategoryId = currentUserProvinceId;
            var operationResult = _checklistApplication.Create(command);


            if (operationResult.IsSucceeded)
            {
                SuccessMessageame = operationResult.Message;
               // TempData["CommandId"] = operationResult.EntityId.ToString(); // تبدیل long به string برای ذخیره در TempData

                var getid = operationResult.EntityId; // گرفتن شناسه رکورد جدید از نتیجه عملیات
                return RedirectToPage("./ChecklistMenu", new { id = getid });
            }

            else
            {
                ErrorMessageame = operationResult.Message;
                return Page();
            }

        }




    }

}
