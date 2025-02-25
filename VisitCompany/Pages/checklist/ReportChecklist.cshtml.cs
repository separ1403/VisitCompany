using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace VisitCompany.Pages.checklist
{
    public class ReportChecklistModel : PageModel
    {
        public ReportChecklistModel(IAccountApplication accountApplication, ICompanyApplication company,IChecklistApplication checklistApplication)
        {
            _accountApplication = accountApplication;
            _company = company;
            _checklistApplication = checklistApplication;
        }

        public ChecklistSearchModel SearchModel;
        public List<ChecklistViewModel> Checklists;
        public SelectList Companies;
        public SelectList Accounts;
        public List<CategoryAverage> CategoryAverage { get; set; } // ??????? ?? ???? ???? ????

        public double OveralAverage { get; set; } // ??????? ?? ???? ???? ????

        public int? CountofAllRecord { get; set; } // ??????? ?? ???? ???? ????

        public int? OtherChecklist { get; set; } // ??????? ?? ???? ???? ????


        // برای تعداد چگ لیست ها
        public int? TotalGeneralChecklists { get; set; } // ??????? ?? ???? ???? ????
        public int? TotalProffChecklists { get; set; } // ??????? ?? ???? ???? ????

        public double? OverallGeneralAverage { get; set; } // ??????? ?? ???? ???? ????
        public double? OverallproffAverage { get; set; } // ??????? ?? ???? ???? ????

        public double? OverallGeneralAverages { get; set; } // ??????? ?? ???? ???? ????
        public double? OverallGeneralPolicyAverages { get; set; } // ??????? ?? ???? ???? ????

        public double? OverallGeneralProffAverages { get; set; } // ??????? ?? ???? ???? ????


      

        public SelectList TypeChecklist;
        public List<CompanyViewModel> Companiess { get; set; }
        public List<AccountViewModel> AccountsList { get; set; }



        private readonly IAccountApplication _accountApplication;
        private readonly ICompanyApplication _company;
        private readonly IChecklistApplication _checklistApplication;



        public void OnGet(ChecklistSearchModel searchModel)
        {
            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);

            ViewData["RolesState"] = Convert.ToInt64(RolesConst.State);
            ViewData["RolesAdministrator"] = Convert.ToInt64(RolesConst.Administrator);

            Companies = new SelectList(_company.GetCompenies(), "Id", "Brand");

            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "Fullname");


            // ??? currentUserRole == Convert.ToInt64(RolesConst.State) ??? ??? ?? ?? ?? ?? ????? ???
            //currentUserProvinceId ?? ?? ????? ????? ?? ??? ??????? ??? ???????
            Checklists = _checklistApplication.Serach(searchModel,
                 (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
               ? currentUserProvinceId
                               : (long?)null);
            //2 ?? ???? ???? ??? ??? ?????? ?? ????? ????? ?? ?????
            //??? ?? ????? ????? ?? repository ???? categoryid contain ???? 
            // ????? ?? ??? 1 ?? 11 ?? ???? ??? ??? ????? ???? ????

            Companiess = _company.Serach(
                new CompanySearchModel(),
                (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
               ? currentUserProvinceId
                               : (long?)null);// ??? ??? Serach ???? ????? ???? ??????? ?? ????????

            // AccountsList = _accountApplication.Search(new AccountSearchModel()); ;
            AccountsList = _accountApplication.Search(
                new AccountSearchModel(),
                (currentUserRole == Convert.ToInt64(RolesConst.State) || currentUserRole == Convert.ToInt64(RolesConst.SystemUser))
                    ? currentUserProvinceId
                    : (long?)null);
            CategoryAverage = Checklists.FirstOrDefault()?.CategoryAverages ?? new List<CategoryAverage>();
            OveralAverage = Checklists.FirstOrDefault()?.OverallAverage ?? 0;

            CountofAllRecord = Checklists.FirstOrDefault()?.CountofAllRecord ?? 0;

            TotalGeneralChecklists = Checklists.FirstOrDefault()?.TotalGeneralChecklists ?? 0;

            TotalProffChecklists = Checklists.FirstOrDefault()?.TotalProffChecklists ?? 0;


            OtherChecklist = CountofAllRecord - TotalGeneralChecklists - TotalProffChecklists;


            // ذخیره میانگین چک‌لیست‌ها در متغیرهای جدید
            OverallGeneralAverage = Checklists.FirstOrDefault()?.overallGeneralAverage ?? 0;
            OverallproffAverage = Checklists.FirstOrDefault()?.overallproffAverage ?? 0;


            OverallGeneralAverages = Checklists.FirstOrDefault()?.overallGeneralAverages ?? 0;
            OverallGeneralPolicyAverages = Checklists.FirstOrDefault()?.overallGeneralPolicyAverages ?? 0;
            OverallGeneralProffAverages = Checklists.FirstOrDefault()?.overallGeneralProffAverages ?? 0;


       


        }

    }
}
