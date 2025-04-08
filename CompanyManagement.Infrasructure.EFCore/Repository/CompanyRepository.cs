using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Domain.CompanyAgg;
using CompanyManagement.Domain.LicenceCategoryAgg;
using CompanyManagement.Infrasructure.EFCore.Migrations;
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
                    .Where(company => company.Accounts.Any(a => a.Id == idAsLong)) // شرط برای بررسی وجود idAsLong در AccountIds
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
            // گرفتن اطلاعات شرکت به همراه محاسبات اولیه
            var company = _companyContext.Companies
                .Where(x => x.Id == id)
                .Include(c => c.Accounts)
                .Include(c => c.CompanyCategory)
                .Include(c => c.StateCategory)
                .Include(c => c.People)
                .Include(c => c.LicenceCategories)
                .Include(c => c.Checklists)
                    .ThenInclude(cl => cl.GeneralChecklist)
                .Include(c => c.Checklists)
                    .ThenInclude(cl => cl.GeneralProffesional)
                .Include(c => c.Checklists)
                    .ThenInclude(cl => cl.GeneralPolicy)
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
                    Address = x.Address,
                    CompanyCreateDate = x.CreationDate.ToFarsi(),
                    Domain = x.Domain,
                    AccountIds = MapAccounts(x.Accounts),
                    Category = x.CompanyCategory.Name,
                    StateCategoryId = x.StateCategoryIds,
                    StatesCategory = x.StateCategory.Name,
                    CountEmployees = x.CountEmployees,
                    CountFolowers = x.CountFolowers,
                    PostalCode=x.PostalCode,

                    People = x.People.Select(a => new PersonDetail
                    {
                        NamePeopleCo = a.NamePeopleCo,
                        RspponsePeopleCo =a.RspponsePeopleCo,
                        PhonePeopleCo = a.PhonePeopleCo,
                    }).ToList(),




                    Licences = x.LicenceCategories.Select(a => new LicenceCategoryViewModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Refrence = a.Refrence
                    }).ToList(),


                    Checklists = x.Checklists.Select(p => new ChecklistViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                      
                        AverageGeneral = p.GeneralChecklist != null && p.GeneralChecklist.AverageGeneral.HasValue
                            ? p.GeneralChecklist.AverageGeneral.Value : 0,
                        AverageGeneralProff = p.GeneralProffesional != null && p.GeneralProffesional.AverageGeneralProffesional.HasValue
                            ? p.GeneralProffesional.AverageGeneralProffesional.Value : 0,
                        AverageGeneralPol = p.GeneralPolicy != null && p.GeneralPolicy.AverageGeneralPolicy.HasValue
                            ? p.GeneralPolicy.AverageGeneralPolicy.Value : 0
                    }).ToList(),

                    ChecklistCount = x.Checklists.Count(),
                    TitleRasm = x.TitleRasm,
                    RegistrationDateRasm= x.RegistrationDateRasm,
                    RegistrationNoRasm = x.RegistrationNoRasm,
                    TaxNumberRasm =x.TaxNumberRasm,
                    PostalCodeRasm = x.PostalCodeRasm,


    })
                .FirstOrDefault();

            if (company == null)
                return null;

            // محاسبه میانگین‌ها به صورت مستقیم در دیتابیس
            var checklistStats = _companyContext.Checklists
             .Where(cl => cl.CompanyId == id)
             .GroupBy(cl => 1) // گروه‌بندی برای محاسبه یک میانگین
             //g یک گروه است که توسط .GroupBy تولید شده است.
//در این مثال، g شامل تمام رکوردهای چک‌لیست مرتبط با شرکت است که در یک گروه با کلید ثابت 1 دسته‌بندی شده‌اند.
             .Select(g => new

             //دستور new { ... } یک شیء جدید از نوع ناشناس (anonymous type) ایجاد می‌کند. این شیء سه ویژگی دارد:
             {
                 AverageGeneral = g.Where(cl => cl.GeneralChecklistID != null && cl.GeneralChecklist.AverageGeneral.HasValue)
                                   .Average(cl => (double?)cl.GeneralChecklist.AverageGeneral) ?? 0,
                 AverageGeneralProff = g.Where(cl => cl.GeneralChecklistProfessionalID != null && cl.GeneralProffesional.AverageGeneralProffesional.HasValue)
                                        .Average(cl => (double?)cl.GeneralProffesional.AverageGeneralProffesional) ?? 0,
                 AverageGeneralPol = g.Where(cl => cl.GeneralChecklistPolicyID != null && cl.GeneralPolicy.AverageGeneralPolicy.HasValue)
                                      .Average(cl => (double?)cl.GeneralPolicy.AverageGeneralPolicy) ?? 0
             })
             .FirstOrDefault();


            if (checklistStats != null)
            {
                company.AverageGeneral = checklistStats.AverageGeneral;
                company.AverageGeneralProff = checklistStats.AverageGeneralProff;
                company.AverageGeneralPol = checklistStats.AverageGeneralPol;
            }

            return company;
        }


        //این متد رو فعلا غیر فعال میکنم و از کد بهنیه استفاده  میکنم اما اگر کد در جایی به مشکل خورد احتمالا مشکل در این است
        //public List<CompanyViewModel> Serach(CompanySearchModel searchModel, long? provincialAdminStateCategoryId = null)
        //{
        //    var companies = _companyContext.Companies
        //   .Include(c => c.CompanyCategory)
        //   .Include(c => c.LicenceCategories)
        //   .Include(c => c.Accounts)
        //   .Include(c => c.Checklists)
        //    .Include(c => c.StateCategory)
        //    .Include(c => c.LicenceCategories)
        //   .ToList(); // داده‌ها به حافظه آورده می‌شوند

        //    // انجام عملیات بررسی null پس از بازیابی داده‌ها
        //    var query = companies.Select(c =>
        //    {
        //        var referDateFrom = c.ReferDateFrom ?? DateTime.MinValue;
        //        var referDateTo = c.ReferDateTo ?? DateTime.MinValue;
        //        double dateDifference = (referDateTo - referDateFrom).TotalDays;

        //        string statusMessage = dateDifference > 10 ? "ارزیاب تعیین شد" :
        //                              dateDifference > 5 ? "در انتظار ارزیابی" :
        //                              dateDifference >= 1 ? "در حال اتمام زمان ارزیابی" :
        //                              "منضی شدن زمان ارزیابی";



        //        return new CompanyViewModel
        //        {
        //            Id = c.Id,
        //            CompanyName = c.CompanyName,
        //            Brand = c.Brand,
        //            ManagerName = c.ManagerName,
        //            SecurityManagerName = c.SecurityManagerName,
        //            PhoneNumber = c.PhoneNumber,
        //            Description = c.Description,
        //            NationalCode = c.NationalCode,
        //            IsActive = c.IsActive,
        //            Category = c.CompanyCategory.Name,
        //            CategoryId = c.CategoryId,
        //            LicenceIds = c.LicenceIds,
        //            Licences = c.LicenceCategories.Select(a => new LicenceCategoryViewModel
        //            {
        //                Id = a.Id,
        //                Name = a.Name,
        //                Refrence = a.Refrence
        //            }).ToList(),

        //            CompanyCreateDate = c.CreationDate.ToFarsi(),
        //            AccountIds = c.AccountIds,
        //            Accounts = c.Accounts.Select(a => new AccountViewModel
        //            {
        //                Id = a.Id,
        //                Fullname = a.Fullname,
        //                StateCategoryId = a.StateCategoryId
        //            }).ToList(),
        //            CheckDate = c.CheckDate.ToFarsi(),
        //            ReferDateFrom = c.ReferDateFrom?.ToFarsi(),
        //            ReferDateTo = c.ReferDateTo?.ToFarsi(),
        //            Domain = c.Domain,
        //            Address = c.Address,
        //            StateCategoryId = c.StateCategoryIds,
        //            StatesCategory = c.StateCategory.Name,
        //            StatusMessage = statusMessage,
        //            //rasmio
        //            TitleRasm = c.TitleRasm,
        //            RegistrationDateRasm = c.RegistrationDateRasm,
        //            RegistrationNoRasm = c.RegistrationNoRasm,
        //            CapitalRasm = c.CapitalRasm,
        //            AddressRasm = c.AddressRasm,
        //            TaxNumberRasm = c.TaxNumberRasm,
        //            PostalCodeRasm = c.PostalCodeRasm,
        //            LastUpdateRasm = c.LastUpdateRasm,
        //            StatusRasm = c.StatusRasm,
        //            EdareKolRasm = c.EdareKolRasm,
        //            VahedSabtiRasm = c.VahedSabtiRasm,


        //        };
        //    }).ToList();


        //    var recordsPerStateChecklist = query   // برای نمودار صفحه ریپورت و 
        //           .GroupBy(x => x.StatesCategory)
        //           .Select(group => new
        //           {
        //               StateCategory = group.Key, // نام شهر
        //               RecordCount = group.Count() // تعداد رکوردها
        //           })
        //           .ToList();

        //    // اعمال فیلترهای جستجو
        //    if (!string.IsNullOrWhiteSpace(searchModel.Name))
        //        query = query.Where(c => c.CompanyName.Contains(searchModel.Name)).ToList();

        //    if (searchModel.CategoryId > 0)
        //        query = query.Where(c => c.CategoryId == searchModel.CategoryId).ToList();


        //    if (searchModel.StateCategoryId > 0)
        //        query = query.Where(c => c.StateCategoryId == searchModel.StateCategoryId).ToList();


        //    if (searchModel.LicenceId > 0)
        //        query = query.Where(c => c.LicenceIds.Contains(searchModel.LicenceId)).ToList();


        //    if (searchModel.LicenceId2 > 0)
        //        query = query.Where(c => c.LicenceIds.Contains(searchModel.LicenceId2)).ToList();

        //    if (!string.IsNullOrWhiteSpace(searchModel.Refrence))
        //        query = query.Where(c => c.Licences.Any(a => a.Refrence.Contains(searchModel.Refrence))).ToList();

        //    if (searchModel.AccountId > 0)
        //        query = query.Where(c => c.AccountIds.Contains(searchModel.AccountId)).ToList();

        //    if (!string.IsNullOrWhiteSpace(searchModel.Brand))
        //        query = query.Where(c => c.Brand.Contains(searchModel.Brand)).ToList();

        //    if (!string.IsNullOrWhiteSpace(searchModel.NationalCode))
        //        query = query.Where(c => c.NationalCode.Contains(searchModel.NationalCode)).ToList();

        //    if (!string.IsNullOrWhiteSpace(searchModel.ManagerName))
        //        query = query.Where(c => c.ManagerName.Contains(searchModel.ManagerName)).ToList();


        //    if (!string.IsNullOrWhiteSpace(searchModel.Address))
        //        query = query.Where(c => c.Address.Contains(searchModel.Address)).ToList();

        //    // اعمال فیلتر براساس StateCategoryId در Account
        //    if (provincialAdminStateCategoryId.HasValue)
        //        query = query.Where(x => x.Accounts.Any(a => a.StateCategoryId == provincialAdminStateCategoryId.Value)).ToList();

        //    //if (provincialAdminStateCategoryId.HasValue)
        //    //    query = query.Where(x => x.AccountIds.Contains(provincialAdminStateCategoryId.Value)).ToList();



        //    // فیلتر شرکت‌هایی که در یک ماه اخیر جهت ارزیابی ارجاع شده‌اند



        //    var oneMonthAgoAssign = DateTime.Now.AddMonths(-1);
        //    var persianCalendar = new System.Globalization.PersianCalendar();
        //    var recentMonthAssign = query
        //        .Where(c =>
        //            !string.IsNullOrWhiteSpace(c.CheckDate) &&
        //            TryParsePersianDate(c.CheckDate, out var checkDateMiladi) &&
        //            checkDateMiladi >= oneMonthAgoAssign)
        //        .ToList();



        //    // اگر رکوردی تاریخ ارجاع نداشت رد میشه و شرط روی ان اعمال نمیشه
        //    //   تعداد شرکت‌های اضافه‌شده در یک ماه اخیر

        //    // تعداد رکوردها در وضعیت "ارزیاب تعیین شد"
        //    int statusAssignedCountMonth = recentMonthAssign.Count(c => c.StatusMessage.Contains("ارزیاب تعیین شد"));

        //    // تعداد رکوردها در وضعیت "در انتظار ارزیابی"
        //    int statusWaitingEvaluationCountMonth = recentMonthAssign.Count(c => c.StatusMessage.Contains("در انتظار ارزیابی"));

        //    // تعداد رکوردها در وضعیت "در حال اتمام زمان ارزیابی"
        //    int statusEndingEvaluationCountMonth = recentMonthAssign.Count(c => c.StatusMessage.Contains("در حال اتمام زمان ارزیابی"));

        //    int statusExpireEvaluationCountMonth = recentMonthAssign.Count(c => c.StatusMessage.Contains("منضی شدن زمان ارزیابی"));

        //    //////////////////////////////////////////////
        //    // فیلتر شرکت‌هایی که در یک هفته اخیر جهت ارزیابی ارجاع شده‌اند
        //    var oneWeekAgoAssign = DateTime.Now.AddDays(-7);
        //    //var recentWeekAssign = query
        //    //    .Where(c => !string.IsNullOrWhiteSpace(c.CheckDate) && DateTime.Parse(c.CheckDate) >= oneWeekAgoAssign)
        //    //    .ToList();

        //    var recentWeekAssign = query
        //       .Where(c =>
        //           !string.IsNullOrWhiteSpace(c.CheckDate) &&
        //           TryParsePersianDate(c.CheckDate, out var checkDateMiladi) &&
        //           checkDateMiladi >= oneWeekAgoAssign)
        //       .ToList();

        //    // اگر رکوردی تاریخ ارجاع نداشت رد میشه و شرط روی ان اعمال نمیشه
        //    //   تعداد شرکت‌های اضافه‌شده در یک ماه اخیر

        //    // تعداد رکوردها در وضعیت "ارزیاب تعیین شد"
        //    int statusAssignedCountWeek = recentWeekAssign.Count(c => c.StatusMessage.Contains("ارزیاب تعیین شد"));

        //    // تعداد رکوردها در وضعیت "در انتظار ارزیابی"
        //    int statusWaitingEvaluationCountWeek = recentWeekAssign.Count(c => c.StatusMessage.Contains("در انتظار ارزیابی"));

        //    // تعداد رکوردها در وضعیت "در حال اتمام زمان ارزیابی"
        //    int statusEndingEvaluationCountWeek = recentWeekAssign.Count(c => c.StatusMessage.Contains("در حال اتمام زمان ارزیابی"));

        //    int statusExpireEvaluationCountWeek = recentWeekAssign.Count(c => c.StatusMessage.Contains("منضی شدن زمان ارزیابی"));




        //    // فیلتر شرکت‌هایی که در یک ماه اخیر اضافه شده‌اند
        //    var oneMonthAgo = DateTime.Now.AddMonths(-1);

        //    var recentCompanies = query
        //      .Where(c =>
        //          !string.IsNullOrWhiteSpace(c.CompanyCreateDate) &&
        //          TryParsePersianDate(c.CompanyCreateDate, out var companyCreateDateMiladi) &&
        //          companyCreateDateMiladi >= oneMonthAgo)
        //      .ToList();
        //    // تعداد شرکت‌های اضافه‌شده در یک ماه اخیر
        //    int recentCompaniesCount = recentCompanies.Count();


        //    // تعداد کل رکوردها
        //    int totalCount = query.Count();

        //    // مرتب‌سازی لیست نهایی
        //    var result = query.OrderByDescending(x => x.Id).ToList();

        //    // افزودن تعداد کل به اولین آیتم
        //    if (result.Any())
        //    {
        //        result.First().TotalCount = totalCount;
        //        result.First().RecentCompaniesCount = recentCompaniesCount; // تعداد شرکت‌های اضافه‌شده در یک ماه اخیر

        //        result.First().StatusAssignedCount = statusAssignedCountMonth;
        //        result.First().StatusWaitingEvaluationCount = statusWaitingEvaluationCountMonth;
        //        result.First().StatusEndingEvaluationCount = statusEndingEvaluationCountMonth;
        //        result.First().StatusExpireEvaluationCount = statusExpireEvaluationCountMonth;

        //        result.First().StatusAssignedCountWeek = statusAssignedCountWeek;
        //        result.First().StatusWaitingEvaluationCountWeek = statusWaitingEvaluationCountWeek;
        //        result.First().StatusEndingEvaluationCountWeek = statusEndingEvaluationCountWeek;
        //        result.First().StatusExpireEvaluationCountWeek = statusExpireEvaluationCountWeek;

        //    }
        //    // متد کمکی برای تبدیل تاریخ شمسی به میلادی

        //    //از این متد به این دلیل استفاده کردم که 

        //    // مشکل کد بالا این است که  در تیکه کد زیر از کدهای بالا متغیر c.CheckDate از نوع شمسی و تاریخ oneMonthAgoAssign از نوع میلادی است

        //    bool TryParsePersianDate(string persianDate, out DateTime gregorianDate)
        //    {
        //        gregorianDate = default;

        //        // بررسی فرمت ورودی
        //        if (DateTime.TryParseExact(persianDate, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempDate))
        //        {
        //            try
        //            {
        //                // جدا کردن اجزای تاریخ
        //                var parts = persianDate.Split('/');
        //                int year = int.Parse(parts[0]);
        //                int month = int.Parse(parts[1]);
        //                int day = int.Parse(parts[2]);

        //                // تبدیل تاریخ شمسی به میلادی
        //                gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
        //                return true;
        //            }
        //            catch
        //            {
        //                // مدیریت خطاهای احتمالی
        //                return false;
        //            }
        //        }
        //        return false;
        //    }
        //    return result;
        //}




        public List<CompanyViewModel> Serach(CompanySearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            var query = _companyContext.Companies
                .Include(c => c.CompanyCategory)
                .Include(c => c.LicenceCategories)
                .Include(c => c.Accounts)
                .Include(c => c.Checklists)
                .Include(c => c.StateCategory)
                .AsQueryable();


            // اعمال فیلترهای جستجو قبل از بارگذاری به حافظه
            // اعمال فیلترهای جستجو
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(c => c.CompanyName.Contains(searchModel.Name));

            if (searchModel.CategoryId > 0)
                query = query.Where(c => c.CategoryId == searchModel.CategoryId);
                       

            if (searchModel.StateCategoryId > 0)
                query = query.Where(c => c.StateCategoryIds == searchModel.StateCategoryId);


            if (searchModel.LicenceId > 0)
                query = query.Where(c => c.LicenceIds.Contains(searchModel.LicenceId));


            if (searchModel.LicenceId2 > 0)
                query = query.Where(c => c.LicenceIds.Contains(searchModel.LicenceId2));


            if (!string.IsNullOrWhiteSpace(searchModel.Refrence))
               query = query.Where(c => c.LicenceCategories.Any(a => a.Refrence.Contains(searchModel.Refrence)));


                if (searchModel.AccountId > 0)
                    query = query.Where(c => c.Accounts.Any(a => a.Id == searchModel.AccountId));


            if (!string.IsNullOrWhiteSpace(searchModel.Brand))
                query = query.Where(c => c.Brand.Contains(searchModel.Brand));

            if (!string.IsNullOrWhiteSpace(searchModel.NationalCode))
                query = query.Where(c => c.NationalCode.Contains(searchModel.NationalCode));

            if (!string.IsNullOrWhiteSpace(searchModel.ManagerName))
                query = query.Where(c => c.ManagerName.Contains(searchModel.ManagerName));


            if (!string.IsNullOrWhiteSpace(searchModel.Address))
                query = query.Where(c => c.Address.Contains(searchModel.Address));



            // اعمال فیلتر براساس StateCategoryId در Account
            if (provincialAdminStateCategoryId.HasValue)
            {
                query = query.Where(c => c.StateCategoryIds == provincialAdminStateCategoryId);
            }


            var companies = query.ToList(); // در اینجا داده‌ها به حافظه بارگذاری می‌شوند

            var result = companies.Select(c =>
            {
                var referDateFrom = c.ReferDateFrom ?? DateTime.MinValue;
                var referDateTo = c.ReferDateTo ?? DateTime.MinValue;
                double dateDifference = (referDateTo - referDateFrom).TotalDays;

                string statusMessage = dateDifference switch
                {
                    > 10 => "ارزیاب تعیین شد",
                    > 5 => "در انتظار ارزیابی",
                    >= 1 => "در حال اتمام زمان ارزیابی",
                    _ => "منضی شدن زمان ارزیابی"
                };

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
                    AccountIds = c.Accounts.Select(a => a.Id).ToList(),
                    Accounts = c.Accounts.Select(a => new AccountViewModel
                    {
                        Id = a.Id,
                        Fullname = a.Fullname,
                        StateCategoryId = a.StateCategoryId
                    }).ToList(),

                    CheckDate = c.CheckDate.ToFarsi(),
                    CheckDateCount = c.CheckDate,
                    ReferDateFrom = c.ReferDateFrom?.ToFarsi(),
                    ReferDateTo = c.ReferDateTo?.ToFarsi(),
                    Domain = c.Domain,
                    Address = c.Address,
                    StateCategoryId = c.StateCategoryIds,
                    StatesCategory = c.StateCategory.Name,
                    StatusMessage = statusMessage,
                    //rasmio
                    TitleRasm = c.TitleRasm,
                    RegistrationDateRasm = c.RegistrationDateRasm,
                    RegistrationNoRasm = c.RegistrationNoRasm,
                    CapitalRasm = c.CapitalRasm,
                    AddressRasm = c.AddressRasm,
                    TaxNumberRasm = c.TaxNumberRasm,
                    PostalCodeRasm = c.PostalCodeRasm,
                    LastUpdateRasm = c.LastUpdateRasm,
                    StatusRasm = c.StatusRasm,
                    EdareKolRasm = c.EdareKolRasm,
                    VahedSabtiRasm = c.VahedSabtiRasm,

                };
            }).OrderByDescending(x => x.Id).ToList();

            // آمار وضعیت‌ها
            var today = DateTime.Today;
            var endOfToday = today.AddDays(1).AddTicks(-1); // 2025-03-22 23:59:59.9999999

            var oneWeekAgo = today.AddDays(-7);
            var oneMonthAgo = today.AddMonths(-1);

            var recentWeekAssignCount = result.Count(c =>
                c.CheckDateCount.HasValue &&
                c.CheckDateCount.Value >= oneWeekAgo &&
                c.CheckDateCount.Value <= endOfToday);

            var recentMonthAssignCount = result.Count(c =>
                c.CheckDateCount.HasValue &&
                c.CheckDateCount.Value >= oneMonthAgo &&
                c.CheckDateCount.Value <= endOfToday);




            var recentMonthAssign = result.Where(c => TryParsePersianDate(c.CheckDate, out var checkDate) && checkDate >= oneMonthAgo ).ToList();
            var recentWeekAssign = result.Where(c => TryParsePersianDate(c.CheckDate, out var checkDate) && checkDate >= oneWeekAgo ).ToList();


          


            //var recentMonthAssignForCount = recentMonthAssignCount.Count();
            //var recentWeekAssignForCount = recentWeekAssignCount.Count;

            if (result.Any())
            {
                var firstItem = result.First();
                firstItem.TotalCount = result.Count;
                firstItem.RecentCompaniesCount = result.Count(c => TryParsePersianDate(c.CompanyCreateDate, out var createDate) && createDate >= oneMonthAgo);
                firstItem.StatusAssignedCount = recentMonthAssign.Count(c => c.StatusMessage == "ارزیاب تعیین شد");
                firstItem.StatusWaitingEvaluationCount = recentMonthAssign.Count(c => c.StatusMessage == "در انتظار ارزیابی");
                firstItem.StatusEndingEvaluationCount = recentMonthAssign.Count(c => c.StatusMessage == "در حال اتمام زمان ارزیابی");
                firstItem.StatusExpireEvaluationCount = recentMonthAssign.Count(c => c.StatusMessage == "منضی شدن زمان ارزیابی");
                firstItem.StatusAssignedCountWeek = recentWeekAssign.Count(c => c.StatusMessage == "ارزیاب تعیین شد");
                firstItem.StatusWaitingEvaluationCountWeek = recentWeekAssign.Count(c => c.StatusMessage == "در انتظار ارزیابی");
                firstItem.StatusEndingEvaluationCountWeek = recentWeekAssign.Count(c => c.StatusMessage == "در حال اتمام زمان ارزیابی");
                firstItem.StatusExpireEvaluationCountWeek = recentWeekAssign.Count(c => c.StatusMessage == "منضی شدن زمان ارزیابی");
                firstItem.StatusAssignedForWeekCount = recentWeekAssignCount; // برای نمایش تعداد ارجاع های داده شده در یک هفته اخیر و پایینی برای ماه اخیر
                firstItem.StatusAssignedForMonthCount = recentMonthAssignCount;
                
            }
            return result;
        }

        private bool TryParsePersianDate(string persianDate, out DateTime gregorianDate)
        {
            gregorianDate = default;
            if (string.IsNullOrWhiteSpace(persianDate)) return false;
            var parts = persianDate.Split('/');
            if (parts.Length != 3 || !int.TryParse(parts[0], out var year) || !int.TryParse(parts[1], out var month) || !int.TryParse(parts[2], out var day)) return false;
            try
            {
                var persianCalendar = new System.Globalization.PersianCalendar();
                gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
                return true;
            }
            catch
            {
                return false;
            }
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
                    AccountIds = c.Accounts.Select(a => a.Id).ToList(),
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
                query = query.Where(x => x.StateCategoryId.Equals(provincialAdminStateCategoryId.Value)).ToList();

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
                Brand = x.Brand

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
                    AccountIds = x.Accounts.Select(a => a.Id).ToList(),
                    Doamin = x.Domain,
                    StateCategoryId = x.StateCategoryIds,
                    Address = x.Address,
                    LicenceIds = x.LicenceIds,

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



        public List<CompanyViewModel> SerachByAccount(CompanySearchModel searchModel, long? currentUserId = null)
        {
            var companies = _companyContext.Companies
           .Include(c => c.CompanyCategory)
           .Include(c => c.LicenceCategories)
           .Include(c => c.Accounts)
           .Include(c => c.Checklists)
            .Include(c => c.StateCategory)
            .Include(c => c.LicenceCategories)
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
                    AccountIds = c.Accounts.Select(a => a.Id).ToList(),
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
                    StatusMessage = statusMessage,
                    //rasmio
                    TitleRasm = c.TitleRasm,
                    RegistrationDateRasm = c.RegistrationDateRasm,
                    RegistrationNoRasm = c.RegistrationNoRasm,
                    CapitalRasm = c.CapitalRasm,
                    AddressRasm = c.AddressRasm,
                    TaxNumberRasm = c.TaxNumberRasm,
                    PostalCodeRasm = c.PostalCodeRasm,
                    LastUpdateRasm = c.LastUpdateRasm,
                    StatusRasm = c.StatusRasm,
                    EdareKolRasm = c.EdareKolRasm,
                    VahedSabtiRasm = c.VahedSabtiRasm,


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

            // ** اعمال فیلتر برای اینکه فقط شرکت‌های مرتبط با کاربر نمایش داده شوند **
            if (currentUserId.HasValue)
                query = query.Where(c => c.AccountIds != null && c.AccountIds.Contains(currentUserId.Value)).ToList();

          

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
            int recentCompaniesCount = recentCompanies.Count();


            // تعداد کل رکوردها
            int totalCount = query.Count();

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


        public static bool TryParsePersianDateCount(string persianDate, out DateTime gregorianDate)
        {
            gregorianDate = DateTime.MinValue;

            if (string.IsNullOrWhiteSpace(persianDate))
                return false;

            try
            {
                // جدا کردن بخش تاریخ و زمان
                var dateTimeParts = persianDate.Split(' ');
                if (dateTimeParts.Length < 2)
                    return false;

                var datePart = dateTimeParts[0]; // ۱۴۰۴/۰۱/۰۲
                var timePart = dateTimeParts[1]; // ۱۲:۴۲:۰۹
                var amPmPart = dateTimeParts.Length == 3 ? dateTimeParts[2] : ""; // ق.ظ یا ب.ظ

                // تبدیل اعداد فارسی به انگلیسی
                datePart = ToEnglishNumber(datePart);
                timePart = ToEnglishNumber(timePart);

                var dateParts = datePart.Split('/');
                if (dateParts.Length != 3)
                    return false;

                int year = int.Parse(dateParts[0]);
                int month = int.Parse(dateParts[1]);
                int day = int.Parse(dateParts[2]);

                var timeParts = timePart.Split(':');
                if (timeParts.Length != 3)
                    return false;

                int hour = int.Parse(timeParts[0]);
                int minute = int.Parse(timeParts[1]);
                int second = int.Parse(timeParts[2]);

                // تنظیم ساعت بر اساس ق.ظ یا ب.ظ
                if (amPmPart == "ب.ظ" && hour < 12)
                    hour += 12;
                else if (amPmPart == "ق.ظ" && hour == 12)
                    hour = 0;

                var pc = new System.Globalization.PersianCalendar();
                gregorianDate = pc.ToDateTime(year, month, day, hour, minute, second, 0);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string ToEnglishNumber(string input)
        {
            return input
                .Replace("۰", "0").Replace("۱", "1").Replace("۲", "2")
                .Replace("۳", "3").Replace("۴", "4").Replace("۵", "5")
                .Replace("۶", "6").Replace("۷", "7").Replace("۸", "8")
                .Replace("۹", "9");
        }

        public Company GetWithAccounts(long id)
        {
            return _companyContext.Companies
                .Include(x => x.Accounts)
                .FirstOrDefault(x => x.Id == id);
        }

    }

}
