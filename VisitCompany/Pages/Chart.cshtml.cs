using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using Framework.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceHost.Areas.Administration.Pages;
using System.Security.Policy;

namespace VisitCompany.Pages
{
    [Authorize]
    public class ChartModel : PageModel
    {
        private readonly IChecklistApplication _checklistApplication;
        private readonly IAccountApplication _accountApplication;
        private readonly ICompanyApplication _company;

        public ChartModel(IAccountApplication accountApplication, ICompanyApplication company, IChecklistApplication checklistApplication)
        {
            _accountApplication = accountApplication;
            _company = company;
            _checklistApplication = checklistApplication;
        }

        public List<string> CompanyNames { get; set; }
        public List<double> AverageGenerals { get; set; }
        public List<double> AverageProff { get; set; }
        public List<string> CreationDates { get; set; }


        public List<string> CompanyNames2 { get; set; }
        public List<double> AverageGenerals2 { get; set; }
        public List<double> AverageProff2 { get; set; }

        public List<string> CreationDates2 { get; set; }


        public ChecklistSearchModel SearchModel;

        public ChecklistSearchModel SearchModel2;

        public SelectList Companies;
        public SelectList Accounts;


        public void OnGet()
        {
            LoadCompanies();
        }


        public void OnPost(ChecklistSearchModel searchModel, ChecklistSearchModel2 searchModel2) // به این دلیل مت رو پست کردم که 
                                                                                                 //برای جلوگیری از ظاهر شدن پارامترها در URL هنگام ارسال فرم، می‌توانید از روش‌های زیر استفاده کنید:
                                                                                                 //استفاده از فرم‌های POST به جای GET: در فرم‌های POST، داده‌ها در URL نمایش داده نمی‌شوند بلکه به‌صورت پنهان در بدنه‌ی درخواست ارسال می‌شوند
        {

            LoadCompanies();

            Companies = new SelectList(_company.GetCompenies(), "Id", "Brand");
            var AvgGen = _checklistApplication.GetAverageGeneralByCompany(searchModel);
            var AvgGen2 = _checklistApplication.GetAverageGeneralByCompareCompany(searchModel2);

            var doubAvgGen = new List<double>();
            var doubAvgProff = new List<double>();
            var strCompany = new List<string>();
            var strCreationDates = new List<string>();

            var doubAvgGen2 = new List<double>();
            var doubAvgProff2 = new List<double>();

            var strCompany2 = new List<string>();
            var strCreationDates2 = new List<string>();

            if (AvgGen != null)
            {
                foreach (var avg in AvgGen)
                {
                    //تو صفحه ی چارت ما دیگه پروفشنال نداریم  بنابر این باید من این رو تغغیر بدم به سایر ارزیابی ها
                    doubAvgGen.Add(avg.AverageGeneral ?? 0);
                    doubAvgProff.Add(avg.AverageProfessional);
                    strCompany.Add(avg.Company);
                    strCreationDates.Add(avg.CalDate.ToFarsi());
                }
            }


            if (AvgGen2 != null)
            {
                foreach (var avg2 in AvgGen2)
                {
                    doubAvgGen2.Add(avg2.AverageGeneral ?? 0);
                    doubAvgProff2.Add(avg2.AverageProfessional);
                    strCompany2.Add(avg2.Company);
                    strCreationDates2.Add(avg2.CalDate.ToFarsi());
                }
            }


            CompanyNames = strCompany;
            AverageGenerals = doubAvgGen;
            AverageProff = doubAvgProff;
            CreationDates = strCreationDates;

            CompanyNames2 = strCompany2;
            AverageProff2 = doubAvgProff2;
            AverageGenerals2 = doubAvgGen2;
            CreationDates2 = strCreationDates2;
        }


        private void LoadCompanies()
        {
            Companies = new SelectList(_company.GetCompenies(), "Id", "Brand");
        }
    }
}
