using System.Globalization;
using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.ChecklistAgg;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    public class ChecklistRepository : RepositoryBase<long, Checklist>, IChecklistRepository
    {
        public ChecklistRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }



        private readonly CompanyContext _companyContext;




       

        public EditChecklist Getdetails(long id)
        {
            return _companyContext.Checklists.Select(x => new EditChecklist()
            {
                Id = x.Id,
                // AccountIds = x.AccountId,
                GeneralchecklistId = x.GeneralChecklistID ?? 0 ,// بررسی null بودن GeneralChecklistID
                Win2019Id = x.Win2019ID ?? 0,
                HpedlId = x.HPEDL380ID ?? 0,
                JuniperId = x.JuniperHardeningID ?? 0,
                GeneralchecklistProffId = x.GeneralChecklistProfessionalID ?? 0,
                GeneralchecklistPolId = x.GeneralChecklistPolicyID ?? 0,







            }).FirstOrDefault(x => x.Id == id);
        }



        //private static List<AccountDto> MappAccounts(List<Account>? accounts)
        //{
        //    if (accounts == null)
        //        return new List<Account>();

        //    return accounts.Select(x => new AccountDto(x.Id, x.Fullname, x.StateCategoryId)).ToList();
        //}




        public List<ChecklistViewModel> GetChecklists()
        {
            return _companyContext.Checklists
                .Include(x => x.Accounts)
                .Include(x => x.Company)
                .Select(x => new ChecklistViewModel
            {
                Id = x.Id,
              
                CompanyName = x.Company.CompanyName,

                   
                 //   AccountId = x.AccountIds ?? 0,
                    CompanyId = x.CompanyId ?? 0,
                   
                

            }).ToList();
        }

     

        public Checklist GetChecklistWithCompany(long id)
        {
            return _companyContext.Checklists.Include(x => x.Company).FirstOrDefault(x => x.Id == id);
        }

        public Checklist GetChecklistWithAccount(long id)
        {
            return _companyContext.Checklists.Include(x => x.Accounts).FirstOrDefault(x => x.Id == id);
        }

        //public long GetLastCompanyId()
        //{
        //    return _companyContext.Checklists.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0;
        //}

        public DateTime GetLastCompanyDate()
        {
            return _companyContext.Checklists.OrderByDescending(x => x.Id).Select(x => x.CreationDate)
                          .FirstOrDefault();
        }

       

        public List<ChecklistViewModel> GetAverageGeneralByCompany(ChecklistSearchModel searchModel)
        {
            bool conditionExecuted = false;
            // داده‌ها را بازیابی کرده و کوئری را مادی‌سازی کنید
            var checklists = _companyContext.Checklists
                .Include(x => x.Company)
                .Include(x => x.GeneralChecklist)
                .Select(x => new ChecklistViewModel
                {
                    AverageGeneral = x.GeneralChecklist.AverageGeneral,
                    CompanyBrand = x.Company.Brand,
                    CompanyId = x.CompanyId,
                    Id = x.Id,
                    CalDate = x.CreationDate,
                   
                })
                .ToList();

            // اعمال فیلتر
            if (searchModel.CompanyId.HasValue && searchModel.CompanyId > 0)
            {
                checklists = checklists.Where(x => x.CompanyId == searchModel.CompanyId.Value).ToList();
                conditionExecuted = true;
            }

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate) && !string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                var startDate = searchModel.StartDate.ToGeorgianDateTime();
                var endDate = searchModel.EndDate.ToGeorgianDateTime();
                checklists = checklists.Where(x => x.CalDate >= startDate && x.CalDate <= endDate).ToList();
                conditionExecuted = true;
            }

            if (searchModel.TopCompaniesCount.HasValue && searchModel.TopCompaniesCount > 0)
            {
                checklists = checklists.OrderByDescending(x => x.AverageGeneral)
                    .Take(searchModel.TopCompaniesCount.Value).ToList();
                conditionExecuted = true;
            }
            if (!conditionExecuted)
            {
                return null;
            }

            return checklists;
        }


        public List<ChecklistViewModel> GetAverageProffesionalByCompany(ChecklistSearchModel searchModel)
        {
            var checklists = _companyContext.Checklists
                .Include(x => x.Company)
                .Select(x => new ChecklistViewModel
                {
                    //AverageProfessional = x.AverageProfessional,
                    CompanyBrand = x.Company.Brand,
                    CompanyId = x.CompanyId,
                    Id = x.Id,
                    CalDate = x.CreationDate,
                })
                .ToList();

            // اعمال فیلتر
            if (searchModel.CompanyId.HasValue && searchModel.CompanyId > 0)
            {
                checklists = checklists.Where(x => x.CompanyId == searchModel.CompanyId.Value).ToList();
            }

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate) && !string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                var startDate = searchModel.StartDate.ToGeorgianDateTime();
                var endDate = searchModel.EndDate.ToGeorgianDateTime();
                checklists = checklists.Where(x => x.CalDate >= startDate && x.CalDate <= endDate).ToList();
            }

            if (searchModel.TopCompaniesCount.HasValue && searchModel.TopCompaniesCount > 0)
            {
                checklists = checklists.OrderByDescending(x => x.AverageGeneral)
                    .Take(searchModel.TopCompaniesCount.Value).ToList();
            }
            else
            {
                checklists = checklists.OrderByDescending(x => x.Id).ToList();
            }

            return checklists;
        }

        //public double AverageGeneralcal(EditGeneralChecklist command)
        //{

        //        var checklist = Get(command.Id);

        //        var hh = checklist.AverageGeneralcal(command);
        //        return hh;

        //}

        public List<ChecklistViewModel> SerachByAccount(long accountId)
        {
            var query = _companyContext.Checklists
                .Include(x => x.Company)
                .Include(x => x.Accounts)
                .Include(x => x.JuniperHardening)
                .Include(x => x.Win2019)
                .Include(x => x.HPEDL380)
                .Include(x => x.GeneralChecklist)
                .Include(x => x.People)  // اضافه کردن رابطه مربوط به افراد
                .Select(x => new ChecklistViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    People = x.People.Select(p => new PersonViewModel
                    {
                        NamePeopleCo = p.NamePeopleCo,
                        RspponsePeopleCo = p.RspponsePeopleCo,
                        PhonePeopleCo = p.PhonePeopleCo
                    }).ToList(),
                    CreattionDate = x.CreationDate.ToFarsi(),
                    CompanyBrand = x.Company.Brand,
                    CompanyId = x.CompanyId,
                    AccountId = x.AccountIds,
                    Accounts = x.Accounts.Select(a => new AccountViewModel
                    {
                        Id = a.Id,
                        Fullname = a.Fullname,
                        StateCategoryId = a.StateCategoryId,


                        // اضافه کردن سایر خواص در صورت نیاز
                    }).ToList(),
                    AverageGeneral = x.GeneralChecklist.AverageGeneral,
                    AverageHpedl380 = x.HPEDL380.AverageHpedl380,
                    AverageJunipper = x.JuniperHardening.AverageJuniper,
                    AverageWin2019 = x.Win2019.AverageWin2019,
                    FinallDescriptionGeneral = x.GeneralChecklist.FinallDescription,
                    FinallDescriptionHpedl380 = x.HPEDL380.FinallDescription,
                    FinallDescriptionJunipper = x.JuniperHardening.FinallDescription,
                    FinallDescriptionWin2019 = x.Win2019.FinallDescription,
                });

            if (accountId > 0)
            {
                // استفاده از Any برای چک کردن وجود حساب کاربری در لیست
                query = query.Where(x => x.AccountId != null && x.AccountId.Any(id => id == accountId));
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }


       


        public List<ChecklistViewModel> GetAverageGeneralByCompareCompany(ChecklistSearchModel2 searchModel)
        {
            bool conditionExecuted = false;
            // داده‌ها را بازیابی کرده و کوئری را مادی‌سازی کنید
            var checklists = _companyContext.Checklists
                .Include(x => x.Company)
                .Select(x => new ChecklistViewModel
                {
                    AverageGeneral = x.GeneralChecklist.AverageGeneral,
                    CompanyBrand = x.Company.Brand,
                    CompanyId = x.CompanyId,
                    Id = x.Id,
                    CalDate = x.CreationDate,
                   // AverageProfessional = x.AverageProfessional,
                })
                .ToList();

            // اعمال فیلتر
            if (searchModel.CompanyId.HasValue && searchModel.CompanyId > 0)
            {
                checklists = checklists.Where(x => x.CompanyId == searchModel.CompanyId.Value).ToList();
                conditionExecuted = true;

            }

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate) && !string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                var startDate = searchModel.StartDate.ToGeorgianDateTime();
                var endDate = searchModel.EndDate.ToGeorgianDateTime();
                checklists = checklists.Where(x => x.CalDate >= startDate && x.CalDate <= endDate).ToList();
                conditionExecuted = true;

            }

            if (searchModel.TopCompaniesCount.HasValue && searchModel.TopCompaniesCount > 0)
            {
                checklists = checklists.OrderByDescending(x => x.AverageGeneral)
                    .Take(searchModel.TopCompaniesCount.Value).ToList();
                conditionExecuted = true;
            }


            if (!conditionExecuted)
            {
                return null;
            }



            return checklists;
        }

        public List<ChecklistViewModel> Serach(ChecklistSearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            // بارگذاری اطلاعات از پایگاه داده
            var query = _companyContext.Checklists
                .Include(x => x.Company)
                .Include(x => x.Accounts)
                .Include(x => x.JuniperHardening)
                .Include(x => x.Win2019)
                .Include(x => x.HPEDL380)
                .Include(x => x.GeneralChecklist)
                .Include(x => x.GeneralProffesional)
                .Include(x => x.GeneralPolicy)


                .Include(x => x.People) // بارگذاری لیست افراد مرتبط
                .Select(x => new ChecklistViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    People = x.People.Select(p => new PersonViewModel
                    {
                        NamePeopleCo = p.NamePeopleCo,
                        RspponsePeopleCo = p.RspponsePeopleCo,
                        PhonePeopleCo = p.PhonePeopleCo
                    }).ToList(),

                    StateCategory = x.Company.StateCategory.Name,
                   

                    CountEmployees = x.CountEmployees,
                    CountFolowers = x.CountFolowers,
                    CompanyBrand = x.Company.Brand,
                    CompanyName = x.Company.CompanyName,
                    CompanyCategory = x.Company.CompanyCategory.Name,
                    CompanyCategoryId = x.Company.CompanyCategory.Id,
                    TypeChecklistGeneral = x.GeneralChecklist.Name,
                    TypeChecklistGeneralProff = x.GeneralProffesional.Name,

                    TypeChecklistGeneralPol = x.GeneralPolicy.Name,
                    TypeChecklistHpedl380 = x.HPEDL380.Name,
                    TypeChecklistunniper = x.JuniperHardening.Name,
                    TypeChecklistwin2019 = x.Win2019.Name,
                    CompanyId = x.CompanyId,
                    AccountId = x.AccountIds,
                    Accounts = x.Accounts.Select(a => new AccountViewModel
                    {
                        Id = a.Id,
                        Fullname = a.Fullname,
                        StateCategoryId = a.StateCategoryId
                    }).ToList(),
                    AverageGeneral = x.GeneralChecklist.AverageGeneral,
                    AverageGeneralProff = x.GeneralProffesional.AverageGeneralProffesional,
                    AverageHpedl380 = x.HPEDL380.AverageHpedl380,
                    AverageGeneralPol = x.GeneralPolicy.AverageGeneralPolicy,

                    AverageJunipper = x.JuniperHardening.AverageJuniper,
                    AverageWin2019 = x.Win2019.AverageWin2019,
                    FinallDescriptionGeneral = x.GeneralChecklist.FinallDescription,
                    FinallDescriptionGeneralProff = x.GeneralProffesional.FinallDescription,
                    FinallDescriptionGeneralPol = x.GeneralPolicy.FinallDescription,

                    FinallDescriptionHpedl380 = x.HPEDL380.FinallDescription,
                    FinallDescriptionJunipper = x.JuniperHardening.FinallDescription,
                    FinallDescriptionWin2019 = x.Win2019.FinallDescription,
                    CreattionDate = x.CreationDate.ToFarsi(), // تغییر فرمت تاریخ به رشته ساده
                    UniqeCodeGeneral = x.GeneralChecklist.UniqueCode,
                    UniqeCodeGeneralproff = x.GeneralProffesional.UniqueCode,
                    UniqeCodeGeneralpol = x.GeneralPolicy.UniqueCode,

                    UniqeCodeHpedl380 = x.HPEDL380.UniqueCode,
                    UniqeCodeJunipper = x.JuniperHardening.UniqueCode,
                    UniqeCodeWin2019 = x.Win2019.UniqueCode,
                });

                  var recordsPerStateCompany = query   // برای نمودار صفحه ریپورت و 
                     .GroupBy(x => x.StateCategory)
                     .Select(group => new
                      {
                        StateCategory = group.Key, // نام شهر
                        RecordCount = group.Count() // تعداد رکوردها
                     })
                     .ToList();


            // اعمال فیلترهای جستجو
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x => x.Title.Contains(searchModel.Name));
            }
            if (!string.IsNullOrWhiteSpace(searchModel.Responsibility))
            {
                query = query.Where(x => x.People.Any(p => p.RspponsePeopleCo.Contains(searchModel.Responsibility)));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.NamePeopleCompany))
            {
                query = query.Where(x => x.People.Any(p => p.NamePeopleCo.Contains(searchModel.NamePeopleCompany)));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Brand))
            {
                query = query.Where(x => x.CompanyBrand.Contains(searchModel.Brand));
            }
            if (!string.IsNullOrWhiteSpace(searchModel.CompanyName))
            {
                query = query.Where(x => x.CompanyName.Contains(searchModel.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.UniqeCode))
            {
                query = query.Where(x =>
                    x.UniqeCodeGeneral.Contains(searchModel.UniqeCode) ||
                    x.UniqeCodeGeneralproff.Contains(searchModel.UniqeCode) ||
                    x.UniqeCodeGeneralpol.Contains(searchModel.UniqeCode) ||
                    x.UniqeCodeWin2019.Contains(searchModel.UniqeCode) ||
                    x.UniqeCodeJunipper.Contains(searchModel.UniqeCode) ||
                    x.UniqeCodeHpedl380.Contains(searchModel.UniqeCode));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.TypeCheckList))
            {
                query = query.Where(x =>
                    x.TypeChecklistGeneral.Contains(searchModel.TypeCheckList) ||
                    x.TypeChecklistGeneralProff.Contains(searchModel.TypeCheckList) ||
                    x.TypeChecklistGeneralPol.Contains(searchModel.TypeCheckList) ||

                    x.TypeChecklistwin2019.Contains(searchModel.TypeCheckList) ||
                    x.TypeChecklistHpedl380.Contains(searchModel.TypeCheckList) ||
                    x.TypeChecklistunniper.Contains(searchModel.TypeCheckList));
            }


            if (searchModel.AccountId > 0)
                query = query.Where(c => c.AccountId.Contains(searchModel.AccountId.Value));


            if (searchModel.CompanyId.HasValue && searchModel.CompanyId > 0)
            {
                query = query.Where(x => x.CompanyId == searchModel.CompanyId.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchModel.ScoreRange))
            {
                var range = searchModel.ScoreRange.Split('-');
                if (range.Length == 2 && double.TryParse(range[0], out double minScore) && double.TryParse(range[1], out double maxScore))
                {
                    query = query.Where(x =>
                        (x.AverageGeneral.HasValue && x.AverageGeneral.Value >= minScore && x.AverageGeneral.Value <= maxScore) ||

                        (x.AverageGeneralProff.HasValue && x.AverageGeneralProff.Value >= minScore && x.AverageGeneralProff.Value <= maxScore) ||
                        (x.AverageHpedl380.HasValue && x.AverageHpedl380.Value >= minScore && x.AverageHpedl380.Value <= maxScore) ||
                         (x.AverageGeneralPol.HasValue && x.AverageGeneralPol.Value >= minScore && x.AverageGeneralPol.Value <= maxScore) ||

                        (x.AverageJunipper.HasValue && x.AverageJunipper.Value >= minScore && x.AverageJunipper.Value <= maxScore) ||
                        (x.AverageWin2019.HasValue && x.AverageWin2019.Value >= minScore && x.AverageWin2019.Value <= maxScore));
                }
            }

            if (provincialAdminStateCategoryId.HasValue)
            {
                query = query.Where(x => x.Accounts.Any(a => a.StateCategoryId == provincialAdminStateCategoryId.Value));
            }

            // انتقال داده‌ها به حافظه
            var result = query.ToList();

            // تعداد کل افراد
            long totalPeopleCount = result.SelectMany(x => x.People).Count();

            // تعداد کل رکوردها
            long totalCount = result.Count();

            // فیلتر چک‌لیست‌های یک ماه اخیر
            var oneMonthAgo = DateTime.Now.AddMonths(-1);

            //   var recentChecklists = result.Where(c => DateTime.Parse(c.CreattionDate) >= oneMonthAgo).ToList();
           
            var persianCalendar = new System.Globalization.PersianCalendar();

            var recentChecklists = result
                .Where(c =>
                    !string.IsNullOrWhiteSpace(c.CreattionDate) &&
                    TryParsePersianDate(c.CreattionDate, out var companyDateMiladi) &&
                    companyDateMiladi >= oneMonthAgo)
                .ToList();


            var oneWeekAgoChecklist = DateTime.Now.AddDays(-7);
         
            var recentWeekChecklist = result
               .Where(c =>
                   !string.IsNullOrWhiteSpace(c.CreattionDate) &&
                   TryParsePersianDate(c.CreattionDate, out var checklistMiladi) &&
                   checklistMiladi >= oneWeekAgoChecklist)
               .ToList();

            int recentChecklistsCount = recentChecklists.Count();
            int oneWeekChecklistsCount = recentWeekChecklist.Count();



            List<CompanyAverage> companyAverages = result
                .GroupBy(c => new { c.CompanyId, c.CompanyName }) // گروه‌بندی بر اساس CompanyId و CompanyName
                .Select(group => new CompanyAverage
                {
                    CompanyId = group.Key.CompanyId,
                    CompanyName = group.Key.CompanyName,
                    AverageScore = group
                        .SelectMany(c => new[] { c.AverageGeneral, c.AverageGeneralProff,c.AverageGeneralPol, c.AverageHpedl380, c.AverageJunipper, c.AverageWin2019 }) // انتخاب تمام میانگین‌ها
                        .Where(avg => avg.HasValue) // حذف مقادیر null
                        .DefaultIfEmpty(0) // اگر مجموعه خالی باشد، مقدار پیش‌فرض (0) جایگزین می‌شود
                        .Average(avg => avg.Value) // محاسبه میانگین مقادیر موجود
                })
                 .OrderBy(company => company.AverageScore) // مرتب‌سازی بر اساس کمترین میانگین
    .Take(10) // انتخاب 10 شرکت با کمترین میانگین
    .ToList();




            List<CategoryAverage> categoryAverages = result
     .GroupBy(c => new { c.CompanyCategoryId, c.CompanyCategory }) // گروه‌بندی بر اساس CompanyCategoryId و CompanyCategory
     .Select(group => new CategoryAverage
     {
         CategoryId = group.Key.CompanyCategoryId ?? 0, // بررسی تهی بودن و اختصاص مقدار پیش‌فرض
         CategoryName = group.Key.CompanyCategory,
         AverageScore = group
             .SelectMany(c => new[] { c.AverageGeneral, c.AverageGeneralProff, c.AverageGeneralPol ,c.AverageHpedl380, c.AverageJunipper, c.AverageWin2019 }) // انتخاب تمام میانگین‌ها
             .Where(avg => avg.HasValue) // حذف مقادیر null
             .DefaultIfEmpty(0) // اگر مجموعه خالی باشد، مقدار پیش‌فرض (0) جایگزین می‌شود
             .Average(avg => avg.Value) // محاسبه میانگین مقادیر موجود
     })
     .OrderByDescending(category => category.AverageScore) // مرتب‌سازی بر اساس بیشترین میانگین
     .ToList();


            // افزودن تعداد کل به اولین آیتم
            if (result.Any())
            {
                result.First().TotalCount = totalCount;
                result.First().TotalPeopleCount = totalPeopleCount;
                result.First().RecentChecklistsCount = recentChecklistsCount;
                result.First().OneWeekChecklistsCount = oneWeekChecklistsCount;
                result.First().AllAverageInOneCompany = companyAverages;
                result.First().CategoryAverages = categoryAverages;

                

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


        public List<ChecklistViewModel> SerachTotal(ChecklistSearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            // بارگذاری اطلاعات از پایگاه داده
            var query = _companyContext.Checklists
                .Include(x => x.Company)
                .Include(x => x.Accounts)
                .Include(x => x.JuniperHardening)
                .Include(x => x.Win2019)
                .Include(x => x.HPEDL380)
                .Include(x => x.GeneralChecklist)
                .Include(x => x.GeneralProffesional)
                .Include(x => x.GeneralPolicy)


                .Include(x => x.People) // بارگذاری لیست افراد مرتبط
                .Select(x => new ChecklistViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    People = x.People.Select(p => new PersonViewModel
                    {
                        NamePeopleCo = p.NamePeopleCo,
                        RspponsePeopleCo = p.RspponsePeopleCo,
                        PhonePeopleCo = p.PhonePeopleCo
                    }).ToList(),
                    CountEmployees = x.CountEmployees,
                    CountFolowers = x.CountFolowers,
                    CompanyBrand = x.Company.Brand,
                    CompanyName = x.Company.CompanyName,
                    CompanyCategory = x.Company.CompanyCategory.Name,
                    TypeChecklistGeneral = x.GeneralChecklist.Name,

                    TypeChecklistGeneralProff = x.GeneralProffesional.Name,
                    TypeChecklistGeneralPol = x.GeneralPolicy.Name,

                    TypeChecklistHpedl380 = x.HPEDL380.Name,
                    TypeChecklistunniper = x.JuniperHardening.Name,
                    TypeChecklistwin2019 = x.Win2019.Name,
                    CompanyId = x.CompanyId,
                    AccountId = x.AccountIds,
                    Accounts = x.Accounts.Select(a => new AccountViewModel
                    {
                        Id = a.Id,
                        Fullname = a.Fullname,
                        StateCategoryId = a.StateCategoryId
                    }).ToList(),
                    AverageGeneral = x.GeneralChecklist.AverageGeneral,
                    AverageGeneralProff = x.GeneralProffesional.AverageGeneralProffesional,

                    AverageGeneralPol = x.GeneralPolicy.AverageGeneralPolicy,

                    AverageHpedl380 = x.HPEDL380.AverageHpedl380,
                    AverageJunipper = x.JuniperHardening.AverageJuniper,
                    AverageWin2019 = x.Win2019.AverageWin2019,
                    FinallDescriptionGeneral = x.GeneralChecklist.FinallDescription,
                    FinallDescriptionGeneralProff = x.GeneralProffesional.FinallDescription,
                    FinallDescriptionGeneralPol = x.GeneralPolicy.FinallDescription,

                    FinallDescriptionHpedl380 = x.HPEDL380.FinallDescription,
                    FinallDescriptionJunipper = x.JuniperHardening.FinallDescription,
                    FinallDescriptionWin2019 = x.Win2019.FinallDescription,
                    CreattionDate = x.CreationDate.ToFarsi(), // تغییر فرمت تاریخ به رشته ساده
                    UniqeCodeGeneral = x.GeneralChecklist.UniqueCode,
                    UniqeCodeGeneralproff = x.GeneralProffesional.UniqueCode,
                    UniqeCodeGeneralpol = x.GeneralPolicy.UniqueCode,

                    UniqeCodeHpedl380 = x.HPEDL380.UniqueCode,
                    UniqeCodeJunipper = x.JuniperHardening.UniqueCode,
                    UniqeCodeWin2019 = x.Win2019.UniqueCode,
                });


            if (provincialAdminStateCategoryId.HasValue)
            {
                query = query.Where(x => x.Accounts.Any(a => a.StateCategoryId == provincialAdminStateCategoryId.Value));
            }

            // اعمال فیلترهای جستجو
            query = query.Where(c =>
      (searchModel.Name != null && c.Title.Contains(searchModel.Name)) ||
      (searchModel.Brand != null && c.CompanyBrand.Contains(searchModel.Brand)) ||
      (searchModel.CompanyName != null && c.CompanyName.Contains(searchModel.CompanyName)) ||
      (!string.IsNullOrWhiteSpace(searchModel.UniqeCode) &&
          (c.UniqeCodeGeneral.Equals(searchModel.UniqeCode) ||
          c.UniqeCodeGeneralproff.Equals(searchModel.UniqeCode) || // حذف پرانتز اضافی
          c.UniqeCodeGeneralpol.Equals(searchModel.UniqeCode) || // حذف پرانتز اضافی
          c.UniqeCodeWin2019.Equals(searchModel.UniqeCode) ||
          c.UniqeCodeJunipper.Equals(searchModel.UniqeCode) ||
          c.UniqeCodeHpedl380.Equals(searchModel.UniqeCode))) || // بستن شرط
      (!string.IsNullOrWhiteSpace(searchModel.PersonName) &&
          c.People.Any(p => p.NamePeopleCo.Contains(searchModel.PersonName))) ||
      (!string.IsNullOrWhiteSpace(searchModel.PersonResponsibility) &&
          c.People.Any(p => p.RspponsePeopleCo.Contains(searchModel.PersonResponsibility))) ||
      (!string.IsNullOrWhiteSpace(searchModel.PersonPhone) &&
          c.People.Any(p => p.PhonePeopleCo.Contains(searchModel.PersonPhone)))
  );



            // تبدیل کوئری نهایی به لیست
            return query.ToList();
        }

        //public double AverageProffcal(EditGeneralChecklist command)
        //{
        //    var checklist = Get(command.Id);
        //    return checklist.AverageProffcal(command);
        //}
    }
}
