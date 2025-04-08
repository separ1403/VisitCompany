using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.LicenceCategory;

namespace CompanyManagement.Application.Contract.Company
{
    public class CompanyViewModel
    {
        public long Id { get; set; }
        public string CompanyName { get;  set; }
        public string Brand { get;  set; }
        public string ManagerName { get;  set; }
        public string SecurityManagerName { get;  set; }
        public string PhoneNumber { get;  set; }
        public string Description { get;  set; }
        public string NationalCode { get;  set; }
        public bool IsActive { get;  set; }
        public string Category { get; set; }
        public double Average { get;  set; }
        public List<AccountViewModel> Accounts { get; set; } = new List<AccountViewModel>(); // تعریف لیست حساب‌ها
        public List<LicenceCategoryViewModel> Licences { get; set; } = new List<LicenceCategoryViewModel>();
        public List<ChecklistViewModel> Checklists { get; set; } = new List<ChecklistViewModel>();
        public long CategoryId { get; set; }
        public List<long>?  LicenceIds { get; set; }
        public string Licence { get; set; }
        public string CompanyCreateDate { get;  set; }
        public List<long>? AccountIds { get; set; } // باید مقداردهی شود
        public string CheckByAccount { get; set; }
        public string Domain { get; set;}
        public string Address { get; set; }
        public string CheckDate { get; set; }
        public DateTime? CheckDateCount { get; set; }

        public string ReferDateFrom { get; set; }
        public string ReferDateTo { get; set; }
        public string StatusMessage { get; set; }
        public long TotalCount { get; set; }
        public long RecentCompaniesCount { get; set; }

        public long StatusAssignedCount { get; set; }
        public int StatusAssignedForWeekCount { get; set; }
        public int StatusAssignedForMonthCount { get; set; }

        public long StatusWaitingEvaluationCount { get; set; }

        public long StatusEndingEvaluationCount { get; set; }
        public long StatusExpireEvaluationCount { get; set; }

        public long StatusAssignedCountWeek { get; set; }
        public long StatusWaitingEvaluationCountWeek { get; set; }

        public long StatusEndingEvaluationCountWeek { get; set; }
        public long StatusExpireEvaluationCountWeek { get; set; }

        public long StateCategoryId { get; set; }
        public string StatesCategory { get; set; }

        public List<PersonDetail>? People { get; set; } = new List<PersonDetail>();
        public string PostalCode { get; set; }
        public long? CountEmployees { get;  set; }
        public long? CountFolowers { get;  set; }
        //for ramio
        public string? TitleRasm { get; set; }
        public string? RegistrationDateRasm { get;  set; }
        public string? RegistrationNoRasm { get;  set; }
        public decimal? CapitalRasm { get;  set; }
        public string? AddressRasm { get;  set; }
        public string? TaxNumberRasm { get;  set; }
        public string? PostalCodeRasm { get;  set; }
        public string? LastUpdateRasm { get;  set; }
        public string? StatusRasm { get;  set; }
        public string? EdareKolRasm { get;  set; }
        public string? VahedSabtiRasm { get;  set; }
        public int? ChecklistCount { get; set; }

        public double AverageGeneral { get; set; }
        public double AverageGeneralProff { get; set; }
        public double AverageGeneralPol { get; set; }



    }
}
