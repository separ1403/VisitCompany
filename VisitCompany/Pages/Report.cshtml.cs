using System.Security.Claims;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Infrastructure.EFCore.Repository;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Infrasructure.EFCore.Repository;
using Framework.Domain;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace VisitCompany.Pages
{
    public class ReportModel : PageModel
    {
        //مشخص شده است تا مقدار آن از query string خوانده شود (برای متد GET).
        [BindProperty(SupportsGet = true)]
        public string Keyword { get; set; }
        public long StatusAssignedCount { get; set; }
        public long StatusWaitingEvaluationCount { get; set; }
        public long StatusEndingEvaluationCount { get; set; }
        public long StatusExpireEvaluationCount { get; set; }

        public long StatusAssignedCountWeek { get; set; }
        public long StatusWaitingEvaluationCountWeek { get; set; }
        public long StatusEndingEvaluationCountWeek { get; set; }
        public long StatusExpireEvaluationCountWeek { get; set; }


        public long TotalCountCompanies { get; set; }
        public long TotalCountCompaniesInOneMonth { get; set; }

        public long TotalCountCheckLists { get; set; }
        public long TotalCountCheckListsInOneMonth { get; set; }
        public long TotalCountCheckListsInOneWeek { get; set; }



        public long TotalCountAccounts { get; set; }
        public long TotalCountAccountsExeptAdm { get; set; }
        public long TotalCountCheckListsPeoples { get; set; }

        public List<CompanyViewModel> CompaniesTen { get; set; }
        public List<AccountViewModel> AccountsTen;
        public List<ChecklistViewModel> ChecklistsTen;

        public List<CompanyViewModel> CompaniesSearch { get; set; } = new List<CompanyViewModel>();
        public List<AccountViewModel> AccountsSearch = new List<AccountViewModel>();
        public List<ChecklistViewModel> ChecklistsSearch = new List<ChecklistViewModel>();
        public List<LicenceCategoryViewModel> LicencesSearch = new List<LicenceCategoryViewModel>();
        public List<PersonViewModel> PersonSearch = new List<PersonViewModel>();

        public List<MergedData> MergedData { get; set; }

        public bool SearchCompanies { get; set; }
        public bool SearchChecklists { get; set; }
        public bool SearchLicences { get; set; }
        public bool SearchPersons { get; set; }

        public List<CompanyAverage> AllAverageInOneCompany { get; set; } // میانگین کلی
        public List<CategoryAverage> CategoryAverage { get; set; } // میانگین بر اساس دسته بندی




        public List<(string PropertyName, long TotalScore)> TopScores;


        private readonly IChecklistApplication _checklistApplication;
        private readonly IAccountApplication _accountApplication;
        private readonly ICompanyApplication _company;
        private readonly ILicenceCategoryApplication _licenceCategoryApplication;
        private readonly IPersonApplication _personApplication;
        private readonly IGeneralChecklistApplication _generalChecklistApplication;

        public ReportModel(IChecklistApplication checklistApplication, IAccountApplication accountApplication, ICompanyApplication company, ILicenceCategoryApplication licenceCategoryApplication, IPersonApplication personApplication, IGeneralChecklistApplication generalChecklistApplication)
        {
            _checklistApplication = checklistApplication;
            _accountApplication = accountApplication;
            _company = company;
            _licenceCategoryApplication = licenceCategoryApplication;
            _personApplication = personApplication;
            _generalChecklistApplication = generalChecklistApplication;
        }

        public void OnGet(string keyword, bool searchCompanies, bool searchChecklists, bool searchLicences, bool searchPersons)
        {
            var currentUserRole = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var currentUserProvinceId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "StateCategoryId")?.Value);

            var oneWeekAgo = DateTime.Now.AddDays(-7);
            var oneMonthAgo = DateTime.Now.AddMonths(-1);

            // دریافت داده‌های چک‌لیست
            var checklistData = _checklistApplication.Serach(new ChecklistSearchModel(),
                currentUserRole == Convert.ToInt64(RolesConst.State) ? currentUserProvinceId : (long?)null);

            // دریافت داده‌های شرکت
            var companyData = _company.Serach(new CompanySearchModel());

            // تجمیع داده‌های چک‌لیست و شرکت‌ها
            var mergedData = checklistData
                .GroupBy(c => c.StateCategory)
                .Select(checklistGroup => new MergedData
                {
                    StateCategory = checklistGroup.Key,
                    ChecklistCount = checklistGroup.Count(),
                    ChecklistCountOneWeek = checklistGroup.Count(c => TryParsePersianDate(c.CreattionDate, out var date) && date >= oneWeekAgo),
                    ChecklistCountOneMonth = checklistGroup.Count(c => TryParsePersianDate(c.CreattionDate, out var date) && date >= oneMonthAgo),
                    CompanyCount = companyData.Count(c => c.StatesCategory == checklistGroup.Key),
                    CompanyCountOneWeek = companyData.Count(c => c.StatesCategory == checklistGroup.Key && TryParsePersianDate(c.CompanyCreateDate, out var date) && date >= oneWeekAgo),
                    CompanyCountOneMonth = companyData.Count(c => c.StatesCategory == checklistGroup.Key && TryParsePersianDate(c.CompanyCreateDate, out var date) && date >= oneMonthAgo)
                })
                .ToList();

            // افزودن شهرهای بدون چک‌لیست
            var companyOnlyData = companyData
                .Where(c => !mergedData.Any(m => m.StateCategory == c.StatesCategory))
                .GroupBy(c => c.StatesCategory)
                .Select(companyGroup => new MergedData
                {
                    StateCategory = companyGroup.Key,
                    ChecklistCount = 0,
                    ChecklistCountOneWeek = 0,
                    ChecklistCountOneMonth = 0,
                    CompanyCount = companyGroup.Count(),
                    CompanyCountOneWeek = companyGroup.Count(c => TryParsePersianDate(c.CompanyCreateDate, out var date) && date >= oneWeekAgo),
                    CompanyCountOneMonth = companyGroup.Count(c => TryParsePersianDate(c.CompanyCreateDate, out var date) && date >= oneMonthAgo)
                });

            // ترکیب داده‌ها
            MergedData = mergedData
                .Union(companyOnlyData)
                .OrderBy(m => m.StateCategory)
                .ToList();
            //این مورد بالا رو برخلاف سایر امارها تو همنیجا تاریخ رو محاسبه کردم بر خلاف قبلی ها که تو متد سرچ بودن گویا این روش بهتر است

            Keyword = keyword?.Trim() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                if (searchCompanies)
                {
                    CompaniesSearch = _company.SerachTotal(new CompanySearchModel { Name = Keyword, Brand = Keyword, NationalCode = Keyword, ManagerName = Keyword, Address = Keyword }, currentUserRole == Convert.ToInt64(RolesConst.State) ? currentUserProvinceId : (long?)null);
                }

                if (searchChecklists)
                {
                    ChecklistsSearch = _checklistApplication.SerachTotal(new ChecklistSearchModel { Name = Keyword, Brand = Keyword, CompanyName = Keyword, UniqeCode = Keyword }, currentUserRole == Convert.ToInt64(RolesConst.State) ? currentUserProvinceId : (long?)null);
                }

                if (searchLicences)
                {
                    LicencesSearch = _licenceCategoryApplication.SearchTotal(new LicenceCategorySearchModel { Name = Keyword, Refrence = Keyword });
                }

                if (searchPersons)
                {
                    PersonSearch = _personApplication.SerachTotal(new PersonSearchModel { NamePeopleCo = Keyword, PhonePeopleCo = Keyword, RspponsePeopleCo = Keyword }, currentUserRole == Convert.ToInt64(RolesConst.State) ? currentUserProvinceId : (long?)null);
                }
            }


            // برای به دسا اوردن تعداد
            var Companies = _company.Serach(new CompanySearchModel(), currentUserRole == Convert.ToInt64(RolesConst.State) ? currentUserProvinceId : (long?)null); // اگر متد Serach بدون فیلتر تمام رکوردها را برگرداند
            var Checklists = _checklistApplication.Serach(new ChecklistSearchModel(), currentUserRole == Convert.ToInt64(RolesConst.State) ? currentUserProvinceId : (long?)null);
            var Accounts = _accountApplication.Search(new AccountSearchModel(), currentUserRole == Convert.ToInt64(RolesConst.State) ? currentUserProvinceId : (long?)null);
            //اگر ر.ل جاری برابر با رول ادمین استانی بود اونوقتای دی شهر رو میفرسته


            // گرفتن تعداد
            TotalCountCompanies = Companies.FirstOrDefault()?.TotalCount ?? 0;  // از اولین رکورد تعداد رو بر میداره و داخل متغیر میریزه
            TotalCountCompaniesInOneMonth = Companies.FirstOrDefault()?.RecentCompaniesCount ?? 0;  // از اولین رکورد تعداد رو بر میداره و داخل متغیر میریزه
            StatusAssignedCount = Companies.FirstOrDefault()?.StatusAssignedCount ?? 0;  // از اولین رکورد تعداد رو بر میداره و داخل متغیر میریزه
            StatusWaitingEvaluationCount = Companies.FirstOrDefault()?.StatusWaitingEvaluationCount ?? 0;  // از اولین رکورد تعداد رو بر میداره و داخل متغیر میریزه
            StatusEndingEvaluationCount = Companies.FirstOrDefault()?.StatusEndingEvaluationCount ?? 0;  // از اولین رکورد تعداد رو بر میداره و داخل متغیر میریزه
            StatusExpireEvaluationCount = Companies.FirstOrDefault()?.StatusExpireEvaluationCount ?? 0;

            StatusAssignedCountWeek = Companies.FirstOrDefault()?.StatusAssignedCountWeek ?? 0;  // از اولین رکورد تعداد رو بر میداره و داخل متغیر میریزه
            StatusWaitingEvaluationCountWeek = Companies.FirstOrDefault()?.StatusWaitingEvaluationCountWeek ?? 0;  // از اولین رکورد تعداد رو بر میداره و داخل متغیر میریزه
            StatusEndingEvaluationCountWeek = Companies.FirstOrDefault()?.StatusEndingEvaluationCountWeek ?? 0;  // از اولین رکورد تعداد رو بر میداره و داخل متغیر میریزه
            StatusExpireEvaluationCountWeek = Companies.FirstOrDefault()?.StatusExpireEvaluationCountWeek ?? 0;


            TotalCountCheckLists = Checklists.FirstOrDefault()?.TotalCount ?? 0;  // از اولین رکورد تعداد رو بر میداره و داخل متغیر میریزه
            TotalCountCheckListsInOneMonth = Checklists.FirstOrDefault()?.RecentChecklistsCount ?? 0;  // از اولین رکورد تعداد رو بر میداره و داخل متغیر میریزه
            TotalCountCheckListsInOneWeek = Checklists.FirstOrDefault()?.OneWeekChecklistsCount ?? 0;
            TotalCountCheckListsInOneWeek = Checklists.FirstOrDefault()?.OneWeekChecklistsCount ?? 0;



            TotalCountAccounts = Accounts.FirstOrDefault()?.TotalCount ?? 0;  // از اولین رکورد تعداد رو بر میداره و داخل متغیر میریزه
            TotalCountAccountsExeptAdm = Accounts.FirstOrDefault()?.ExcludedRoleCount ?? 0;
            TotalCountCheckListsPeoples = Checklists.FirstOrDefault()?.TotalPeopleCount ?? 0;
            AllAverageInOneCompany = Checklists.FirstOrDefault()?.AllAverageInOneCompany ?? new List<CompanyAverage>();
            CategoryAverage = Checklists.FirstOrDefault()?.CategoryAverages ?? new List<CategoryAverage>();

            // گرفتن ۱۰ رکورد آخر
            CompaniesTen = Companies.TakeLast(10).ToList();
            ChecklistsTen = Checklists.TakeLast(10).ToList();
            AccountsTen = Accounts.TakeLast(10).ToList();


            // در بین 3 جدول از جداول عمومی ها  میگردد
            // امکان گردش در تمام جداول هم هست
            TopScores = _generalChecklistApplication.GetMostVulnerableProperties();

        }


        // متد کمکی تبدیل تاریخ شمسی به میلادی
        private bool TryParsePersianDate(string persianDate, out DateTime gregorianDate)
        {
            gregorianDate = default;
            try
            {
                var parts = persianDate.Split('/');
                int year = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int day = int.Parse(parts[2]);
                var persianCalendar = new System.Globalization.PersianCalendar();
                gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
