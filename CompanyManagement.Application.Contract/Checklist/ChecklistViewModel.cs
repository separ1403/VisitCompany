using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.StateCategory;
using Framework.Application;
using System;
using System.Collections.Generic;

namespace CompanyManagement.Application.Contract.Checklist
{
    public class ChecklistViewModel
    {
        public long Id { get; set; }

        public string Title { get; set; }
        public long? CountEmployees { get; set; }
        public long? CountFolowers { get; set; }

        public long? CompanyId { get; set; }
        public long? CompanyCategoryId { get; set; }

        public string CompanyBrand { get; set; }
        public string StateCategory { get; set; }

        public string CompanyName { get; set; }
        public string CompanyCategory { get; set; }

        public string TypeChecklistGeneral { get; set; }
        public string TypeChecklistGeneralProff { get; set; }
        public string TypeChecklistGeneralPol { get; set; }


        public string TypeChecklistHpedl380 { get; set; }
        public string TypeChecklistunniper { get; set; }
        public string TypeChecklistwin2019 { get; set; }

        public long TotalCount { get; set; }
        public long TotalPeopleCount { get; set; }
        public long RecentChecklistsCount { get; set; }
        public long OneWeekChecklistsCount { get; set; }
        public   List<CompanyAverage> AllAverageInOneCompany { get; set; }
        public List<CategoryAverage> CategoryAverages { get; set; }




        public string CreattionDate { get; set; }

        public List<long>? AccountId { get; set; }
        //   public string? Accounts { get; set; }
        public List<AccountViewModel> Accounts { get; set; } = new List<AccountViewModel>(); // تعریف لیست حساب‌ها

        public long AccountCount { get; set; } // تعداد چک لیست‌های انجام‌شده توسط هر نفر

        public double? AverageGeneral { get; set; }
        public double? AverageHpedl380 { get; set; }
        public double? AverageWin2019 { get; set; }
        public double? AverageJunipper { get; set; }
        public double? AverageGeneralProff { get; set; }
        public double? AverageGeneralPol { get; set; }



        public string? FinallDescriptionGeneral { get; set; }
        public string? FinallDescriptionGeneralProff { get; set; }
        public string? FinallDescriptionGeneralPol { get; set; }


        public string? FinallDescriptionHpedl380 { get; set; }
        public string? FinallDescriptionWin2019 { get; set; }
        public string? FinallDescriptionJunipper { get; set; }
        public string? UniqeCodeHpedl380 { get; set; }
        public string? UniqeCodeWin2019 { get; set; }
        public string? UniqeCodeJunipper { get; set; }
        public string? UniqeCodeGeneral { get; set; }
        public string? UniqeCodeGeneralproff { get; set; }
        public string? UniqeCodeGeneralpol { get; set; }








        // لیست افرادی که در این چک‌لیست حضور دارند
        public List<PersonViewModel> People { get; set; } = new List<PersonViewModel>();

        public DateTime CalDate { get; set; }
    }

    // ViewModel برای افراد موجود در چک‌لیست



    public class CompanyAverage
    {
        public long? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public double AverageScore { get; set; }
    }

    public class CategoryAverage
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double AverageScore { get; set; }
    }
}