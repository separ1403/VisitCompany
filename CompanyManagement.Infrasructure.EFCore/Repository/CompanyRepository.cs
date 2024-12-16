using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Domain.CompanyAgg;
using CompanyManagement.Domain.LicenceCategoryAgg;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    [Authorize]
    public class CompanyRepository : RepositoryBase<long, Company>, ICompanyRepository
    {
      

        private readonly CompanyContext _companyContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthHelper _authHelper;

        public CompanyRepository(CompanyContext companyContext, IHttpContextAccessor httpContextAccessor, IAuthHelper authHelper) : base(companyContext)
        {
            _companyContext = companyContext;
            _httpContextAccessor = httpContextAccessor;
            _authHelper = authHelper;
        }

        public List<CompanyViewModel> GetCompeniesWithUsername()
        {
            if (_authHelper.IsAuthenticated())
            {
                string idFromSession = _httpContextAccessor.HttpContext.Session.GetString("CommandId"); // inja  az session get karde va khandeh

                if (string.IsNullOrEmpty(idFromSession)) //بسته شدن مرورگر به‌طور پیش‌فرض باعث پاک شدن سشن می‌شود، زیرا سشن‌ها به کوکی‌های موقتی متکی هستند که در هنگام بسته شدن مرورگر از بین می‌روند.
                {
                    // مدیریت وضعیت زمانی که مقدار CommandId در سشن وجود ندارد
                    _httpContextAccessor.HttpContext.Response.Redirect("/Account");
                    return new List<CompanyViewModel>();
                }


                long idAsLong = long.Parse(idFromSession);

                return _companyContext.Companies
                    .Where(company => company.AccountIds.Contains(idAsLong)) // شرط برای بررسی وجود idAsLong در AccountIds
                    .Select(x => new CompanyViewModel()
                    {
                        Id = x.Id,
                        CompanyName = x.CompanyName,
                        Brand = x.Brand

                    }).ToList();
               
            }
            else
            {
                return new List<CompanyViewModel>();
            }


        }
        public List<CompanyViewModel> GetCompaniesByCategoryId(int categoryId)
        {
            return _companyContext.Companies
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.CompanyCategory)
                .Select(x => new CompanyViewModel()
                {
                    Id = x.Id,
                    CompanyName = x.CompanyName,
                    Brand = x.Brand

                }).ToList();

        }



        public CompanyViewModel GetdetailPartialview(long id)
        {
            {
                return _companyContext.Companies
                    .Where(x => x.Id == id)
                    .Include(c => c.Accounts)
                    .Include(c => c.CompanyCategory)
                    .Include(c => c.StateCategory)


                    .Select(x => new CompanyViewModel
                    {
                        Id = x.Id,
                        CompanyName = x.CompanyName,
                        Brand = x.Brand,
                        ManagerName = x.ManagerName,
                        SecurityManagerName = x.SecurityManagerName,
                        PhoneNumber = x.PhoneNumber,
                        CategoryId = x.CategoryId,
                        Description = x.Description,
                        NationalCode = x.NationalCode,
                        IsActive = x.IsActive,
                        Address=x.Address,
                        CompanyCreateDate = x.CreationDate.ToFarsi(),
                        Domain = x.Domain,
                        AccountIds = MapAccounts(x.Accounts),
                        Category = x.CompanyCategory.Name,
                        StateCategoryId = x.StateCategoryIds,
                        StatesCategory = x.StateCategory.Name,

                    })
                    .FirstOrDefault();
            }
        }


        public List<CompanyViewModel> Serach(CompanySearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            var companies = _companyContext.Companies
           .Include(c => c.CompanyCategory)
           .Include(c => c.LicenceCategories)
           .Include(c => c.Accounts)
           .Include(c => c.Checklists)
            .Include(c => c.StateCategory)
           .ToList(); // داده‌ها به حافظه آورده می‌شوند

            // انجام عملیات بررسی null پس از بازیابی داده‌ها
            var query = companies.Select(c =>
            {
                var referDateFrom = c.ReferDateFrom ?? DateTime.MinValue;
                var referDateTo = c.ReferDateTo ?? DateTime.MinValue;
                double dateDifference = (referDateTo - referDateFrom).TotalDays;

                string statusMessage = dateDifference > 10 ? "ارزیاب تعیین شد" :
                                      dateDifference > 5 ? "در انتظار ارزیابی" :
                                      dateDifference >= 1 ? "در حال اتمام زمان ارزیابی" :
                                      "منضی شدن زمان ارزیابی";



                return new CompanyViewModel
                {
                    Id = c.Id,
                    CompanyName = c.CompanyName,
                    Brand = c.Brand,
                    ManagerName = c.ManagerName,
                    SecurityManagerName = c.SecurityManagerName,
                    PhoneNumber = c.PhoneNumber,
                    Description = c.Description,
                    NationalCode = c.NationalCode,
                    IsActive = c.IsActive,
                    Category = c.CompanyCategory.Name,
                    CategoryId = c.CategoryId,
                    LicenceIds = c.LicenceIds,
                    Licences= c.LicenceCategories.Select(a => new LicenceCategoryViewModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Refrence =a.Refrence
                    }).ToList(),

                    CompanyCreateDate = c.CreationDate.ToFarsi(),
                    AccountIds = c.AccountIds,
                    Accounts = c.Accounts.Select(a => new AccountViewModel
                    {
                        Id = a.Id,
                        Fullname = a.Fullname,
                        StateCategoryId = a.StateCategoryId
                    }).ToList(),
                    CheckDate = c.CheckDate.ToFarsi(),
                    ReferDateFrom = c.ReferDateFrom?.ToFarsi(),
                    ReferDateTo = c.ReferDateTo?.ToFarsi(),
                    Domain = c.Domain,
                    Address = c.Address,
                    StateCategoryId = c.StateCategoryIds,
                    StatesCategory = c.StateCategory.Name,
                    StatusMessage = statusMessage
                };
            }).ToList();

            
            var recordsPerStateChecklist = query   // برای نمودار صفحه ریپورت و 
                   .GroupBy(x => x.StatesCategory)
                   .Select(group => new
                   {
                       StateCategory = group.Key, // نام شهر
                       RecordCount = group.Count() // تعداد رکوردها
                   })
                   .ToList();
            // اعمال فیلترهای جستجو
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(c => c.CompanyName.Contains(searchModel.Name)).ToList();

            if (searchModel.CategoryId > 0)
                query = query.Where(c => c.CategoryId == searchModel.CategoryId).ToList();


            if (searchModel.StateCategoryId > 0)
                query = query.Where(c => c.StateCategoryId == searchModel.StateCategoryId).ToList();


            if (searchModel.LicenceId > 0)
                query = query.Where(c => c.LicenceIds.Contains(searchModel.LicenceId)).ToList();

            if (searchModel.LicenceId2 > 0)
                query = query.Where(c => c.LicenceIds.Contains(searchModel.LicenceId2)).ToList();

            if (!string.IsNullOrWhiteSpace(searchModel.Refrence))
                query = query.Where(c => c.Licences.Any(a => a.Refrence.Contains(searchModel.Refrence))).ToList();

            if (searchModel.AccountId > 0)
                query = query.Where(c => c.AccountIds.Contains(searchModel.AccountId)).ToList();

            if (!string.IsNullOrWhiteSpace(searchModel.Brand))
                query = query.Where(c => c.Brand.Contains(searchModel.Brand)).ToList();

            if (!string.IsNullOrWhiteSpace(searchModel.NationalCode))
                query = query.Where(c => c.NationalCode.Contains(searchModel.NationalCode)).ToList();

            if (!string.IsNullOrWhiteSpace(searchModel.ManagerName))
                query = query.Where(c => c.ManagerName.Contains(searchModel.ManagerName)).ToList();

            if (!string.IsNullOrWhiteSpace(searchModel.Address))
                query = query.Where(c => c.Address.Contains(searchModel.Address)).ToList();

            // اعمال فیلتر براساس StateCategoryId در Account
            if (provincialAdminStateCategoryId.HasValue)
                query = query.Where(x => x.Accounts.Any(a => a.StateCategoryId == provincialAdminStateCategoryId.Value)).ToList();


            // فیلتر شرکت‌هایی که در یک ماه اخیر جهت ارزیابی ارجاع شده‌اند
            
            
            
            var oneMonthAgoAssign = DateTime.Now.AddMonths(-1);
            var persianCalendar = new System.Globalization.PersianCalendar();
            var recentMonthAssign = query
                .Where(c =>
                    !string.IsNullOrWhiteSpace(c.CheckDate) &&
                    TryParsePersianDate(c.CheckDate, out var checkDateMiladi) &&
                    checkDateMiladi >= oneMonthAgoAssign)
                .ToList();

          

            // اگر رکوردی تاریخ ارجاع نداشت رد میشه و شرط روی ان اعمال نمیشه
            //   تعداد شرکت‌های اضافه‌شده در یک ماه اخیر

            // تعداد رکوردها در وضعیت "ارزیاب تعیین شد"
            int statusAssignedCountMonth = recentMonthAssign.Count(c => c.StatusMessage.Contains("ارزیاب تعیین شد"));

            // تعداد رکوردها در وضعیت "در انتظار ارزیابی"
            int statusWaitingEvaluationCountMonth = recentMonthAssign.Count(c => c.StatusMessage.Contains("در انتظار ارزیابی"));

            // تعداد رکوردها در وضعیت "در حال اتمام زمان ارزیابی"
            int statusEndingEvaluationCountMonth = recentMonthAssign.Count(c => c.StatusMessage.Contains("در حال اتمام زمان ارزیابی"));

            int statusExpireEvaluationCountMonth = recentMonthAssign.Count(c => c.StatusMessage.Contains("منضی شدن زمان ارزیابی"));

            //////////////////////////////////////////////
            // فیلتر شرکت‌هایی که در یک هفته اخیر جهت ارزیابی ارجاع شده‌اند
            var oneWeekAgoAssign = DateTime.Now.AddDays(-7);
            //var recentWeekAssign = query
            //    .Where(c => !string.IsNullOrWhiteSpace(c.CheckDate) && DateTime.Parse(c.CheckDate) >= oneWeekAgoAssign)
            //    .ToList();

            var recentWeekAssign = query
               .Where(c =>
                   !string.IsNullOrWhiteSpace(c.CheckDate) &&
                   TryParsePersianDate(c.CheckDate, out var checkDateMiladi) &&
                   checkDateMiladi >= oneWeekAgoAssign)
               .ToList();

            // اگر رکوردی تاریخ ارجاع نداشت رد میشه و شرط روی ان اعمال نمیشه
            //   تعداد شرکت‌های اضافه‌شده در یک ماه اخیر

            // تعداد رکوردها در وضعیت "ارزیاب تعیین شد"
            int statusAssignedCountWeek = recentWeekAssign.Count(c => c.StatusMessage.Contains("ارزیاب تعیین شد"));

            // تعداد رکوردها در وضعیت "در انتظار ارزیابی"
            int statusWaitingEvaluationCountWeek = recentWeekAssign.Count(c => c.StatusMessage.Contains("در انتظار ارزیابی"));

            // تعداد رکوردها در وضعیت "در حال اتمام زمان ارزیابی"
            int statusEndingEvaluationCountWeek = recentWeekAssign.Count(c => c.StatusMessage.Contains("در حال اتمام زمان ارزیابی"));

            int statusExpireEvaluationCountWeek = recentWeekAssign.Count(c => c.StatusMessage.Contains("منضی شدن زمان ارزیابی"));




            // فیلتر شرکت‌هایی که در یک ماه اخیر اضافه شده‌اند
            var oneMonthAgo = DateTime.Now.AddMonths(-1);

            var recentCompanies = query
              .Where(c =>
                  !string.IsNullOrWhiteSpace(c.CompanyCreateDate) &&
                  TryParsePersianDate(c.CompanyCreateDate, out var companyCreateDateMiladi) &&
                  companyCreateDateMiladi >= oneMonthAgo)
              .ToList();
            // تعداد شرکت‌های اضافه‌شده در یک ماه اخیر
            int recentCompaniesCount = recentCompanies.Count;


            // تعداد کل رکوردها
            int totalCount = query.Count;

            // مرتب‌سازی لیست نهایی
            var result = query.OrderByDescending(x => x.Id).ToList();

            // افزودن تعداد کل به اولین آیتم
            if (result.Any())
            {
                result.First().TotalCount = totalCount;
                result.First().RecentCompaniesCount = recentCompaniesCount; // تعداد شرکت‌های اضافه‌شده در یک ماه اخیر


                result.First().StatusAssignedCount = statusAssignedCountMonth;
                result.First().StatusWaitingEvaluationCount = statusWaitingEvaluationCountMonth;
                result.First().StatusEndingEvaluationCount = statusEndingEvaluationCountMonth;
                result.First().StatusExpireEvaluationCount = statusExpireEvaluationCountMonth;

                result.First().StatusAssignedCountWeek = statusAssignedCountWeek;
                result.First().StatusWaitingEvaluationCountWeek = statusWaitingEvaluationCountWeek;
                result.First().StatusEndingEvaluationCountWeek = statusEndingEvaluationCountWeek;
                result.First().StatusExpireEvaluationCountWeek = statusExpireEvaluationCountWeek;


            }
            // متد کمکی برای تبدیل تاریخ شمسی به میلادی

            //از این متد به این دلیل استفاده کردم که 

            // مشکل کد بالا این است که  در تیکه کد زیر از کدهای بالا متغیر c.CheckDate از نوع شمسی و تاریخ oneMonthAgoAssign از نوع میلادی است

            bool TryParsePersianDate(string persianDate, out DateTime gregorianDate)
            {
                gregorianDate = default;

                // بررسی فرمت ورودی
                if (DateTime.TryParseExact(persianDate, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempDate))
                {
                    try
                    {
                        // جدا کردن اجزای تاریخ
                        var parts = persianDate.Split('/');
                        int year = int.Parse(parts[0]);
                        int month = int.Parse(parts[1]);
                        int day = int.Parse(parts[2]);

                        // تبدیل تاریخ شمسی به میلادی
                        gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
                        return true;
                    }
                    catch
                    {
                        // مدیریت خطاهای احتمالی
                        return false;
                    }
                }
                return false;
            }
            return result;
        }


        public List<CompanyViewModel> SerachTotal(CompanySearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            var companies = _companyContext.Companies
           .Include(c => c.CompanyCategory)
           .Include(c => c.LicenceCategories)
           .Include(c => c.Accounts)
           .Include(c => c.Checklists)
            .Include(c => c.StateCategory)
           .ToList(); // داده‌ها به حافظه آورده می‌شوند

            // انجام عملیات بررسی null پس از بازیابی داده‌ها
            var query = companies.Select(c =>
            {
                var referDateFrom = c.ReferDateFrom ?? DateTime.MinValue;
                var referDateTo = c.ReferDateTo ?? DateTime.MinValue;
                double dateDifference = (referDateTo - referDateFrom).TotalDays;

                string statusMessage = dateDifference > 10 ? "ارزیاب تعیین شد" :
                                      dateDifference > 5 ? "در انتظار ارزیابی" :
                                      dateDifference >= 1 ? "در حال اتمام زمان ارزیابی" :
                                      "منضی شدن زمان ارزیابی";



                return new CompanyViewModel
                {
                    Id = c.Id,
                    CompanyName = c.CompanyName,
                    Brand = c.Brand,
                    ManagerName = c.ManagerName,
                    SecurityManagerName = c.SecurityManagerName,
                    PhoneNumber = c.PhoneNumber,
                    Description = c.Description,
                    NationalCode = c.NationalCode,
                    IsActive = c.IsActive,
                    Category = c.CompanyCategory.Name,
                    CategoryId = c.CategoryId,
                    LicenceIds = c.LicenceIds,
                    Licences = c.LicenceCategories.Select(a => new LicenceCategoryViewModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Refrence = a.Refrence
                    }).ToList(),

                    CompanyCreateDate = c.CreationDate.ToFarsi(),
                    AccountIds = c.AccountIds,
                    Accounts = c.Accounts.Select(a => new AccountViewModel
                    {
                        Id = a.Id,
                        Fullname = a.Fullname,
                        StateCategoryId = a.StateCategoryId
                    }).ToList(),
                    CheckDate = c.CheckDate.ToFarsi(),
                    ReferDateFrom = c.ReferDateFrom?.ToFarsi(),
                    ReferDateTo = c.ReferDateTo?.ToFarsi(),
                    Domain = c.Domain,
                    Address = c.Address,
                    StateCategoryId = c.StateCategoryIds,
                    StatesCategory = c.StateCategory.Name,
                    StatusMessage = statusMessage
                };
            }).ToList();


            if (provincialAdminStateCategoryId.HasValue)
                query = query.Where(x => x.StateCategoryId.Equals( provincialAdminStateCategoryId.Value)).ToList();

            query = query.Where(c =>
                (searchModel.Name != null && c.CompanyName.Contains(searchModel.Name)) ||
                (searchModel.Brand != null && c.Brand.Contains(searchModel.Brand)) ||
                (searchModel.NationalCode != null && c.NationalCode.Contains(searchModel.NationalCode)) ||
                (searchModel.Address != null && c.Address.Contains(searchModel.Address)) ||
                (searchModel.ManagerName != null && c.ManagerName.Contains(searchModel.ManagerName))
            ).ToList();


            return query;
        }

        private static List<long> MapAccounts(List<Account>? accounts)
        {
            if (accounts == null)
                return new List<long>();

            return accounts.Select(x => x.Id).ToList();
        }

        private static List<long> MapLicences(List<LicenceCategory>? licenceCategories)
        {
            // بررسی اینکه لیست مجوزها null یا خالی نباشد
            if (licenceCategories == null || !licenceCategories.Any())
                return new List<long>();

            // نگاشت شناسه‌های مجوزها به لیست شناسه‌ها
            return licenceCategories.Select(x => x.Id).ToList();
        }

        public List<CompanyViewModel> GetCompenies()
        {
            return _companyContext.Companies.Select(x => new CompanyViewModel()
            {
                Id = x.Id,
                CompanyName = x.CompanyName,
                Brand= x.Brand

            }).ToList();


        }

        public EditCompany Getdetails(long id)
        {
            return _companyContext.Companies
                .Where(x => x.Id == id)
                .Select(x => new EditCompany
                {
                    Id = x.Id,
                    CompanyName = x.CompanyName,
                    Brand = x.Brand,
                    ManagerName = x.ManagerName,
                    SecurityManagerName = x.SecurityManagerName,
                    PhoneNumber = x.PhoneNumber,
                    CategoryId = x.CategoryId,
                    Description = x.Description,
                    NationalCode = x.NationalCode,
                   // AccountIds = x.Accounts != null ? x.Accounts.Select(a => a.Id).ToList() : new List<long>()
                    AccountIds = x.AccountIds, // اضافه کردن این خط
                    Doamin = x.Domain,
                    StateCategoryId = x.StateCategoryIds,
                })
                .FirstOrDefault();
        }

        public List<CompanyViewModel> GetCompaniesByLicenceId(int licenceId)
        {
            return _companyContext.Companies
               .Where(x => x.LicenceIds.Contains(licenceId))
               .Include(x => x.LicenceCategories)
               .Select(x => new CompanyViewModel()
               {
                   Id = x.Id,
                   CompanyName = x.CompanyName,
                   Brand = x.Brand

               }).ToList();
        }
    }

}
