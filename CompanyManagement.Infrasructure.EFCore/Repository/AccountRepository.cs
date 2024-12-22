using AccountManagement.Application.Contracts.Account;
using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Infrasructure.EFCore;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public  class AccountRepository:RepositoryBase<long,Account> , IAccountRepository
    {
        private readonly CompanyContext _context;
        public AccountRepository( CompanyContext context) : base(context)
        {
            _context = context;
        }

        public List<Account> GetAccountsByIds(List<long> accountIds)
        {
            return _context.Accounts.Where(a => accountIds.Contains(a.Id)).ToList();// account hayee ro az table account mide ke id on ha barabar bashe ba Accountids ha
            //yani az roye accountid ha account ha ro joda mikone
        }

        public AccountViewModel GetLastLogin(string searchModel)
        {
            var query = _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                Name=x.Name,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                UserName = x.UserName,
                LastLogin = x.LastLogin.ToFarsiWithTime(),
                PreviousLogin=x.PreviousLogin.ToFarsiWithTime()
                
            });

            if (!string.IsNullOrWhiteSpace(searchModel))
                query = query.Where(x => x.UserName.Equals(searchModel) || x.Mobile.Equals(searchModel));

            // استفاده از FirstOrDefault برای گرفتن اولین نتیجه یا مقدار پیش‌فرض (null) اگر هیچ نتیجه‌ای موجود نباشد
            return query.FirstOrDefault();
        }


        public Account GetBy(string  userName)
        {
            
            return _context.Accounts.FirstOrDefault(x => x.UserName == userName);
        }

        public Account GetById(long id)
        {

            return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }
        public Account GetByMobile(string mobile)
        {
            return _context.Accounts.FirstOrDefault(x => x.Mobile == mobile);
        }


        public List<AccountViewModel> GetAccounts()
        {
            return _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Fullname = x.Fullname
            }).ToList();
        }

        public EditAccount Getdetails(long id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                Name = x.Name,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                Username = x.UserName,
                StateCategoryId = x.StateCategoryId,
                Description=x.Description,
            }).FirstOrDefault(x => x.Id == id);
        }

        public ChangePassword Getdetail(long id)
        {
            return _context.Accounts.Select(x => new ChangePassword()
            {
                Id = x.Id,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> Serach(AccountSearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            var query = _context.Accounts
               .Include(x => x.Role)
               .Include(x => x.LoginAttempts) // اضافه کردن تاریخچه ورود
               .Select(x => new AccountViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   Fullname = x.Fullname,
                   Mobile = x.Mobile,
                   Role = x.Role.Name,
                   RoleId = x.RoleId,
                   StateCategoryId = x.StateCategoryId,
                   StatesCategory = x.StateCategory.Name,
                   UserName = x.UserName,
                   IsActive = x.IsActive,
                   Description=x.Description,
                   CreationDate = x.CreationDate.ToFarsiWithTime(),
                   LastLogin = x.LastLogin.ToFarsiWithTime(),
                   PreviousLogin = x.PreviousLogin.HasValue ? x.PreviousLogin.Value.ToFarsiWithTime() : "N/A",
                   LastLogins = x.LoginAttempts
                       .OrderByDescending(l => l.LoginTime)
                       .Take(20)
                       .Select(l => l.LoginTime.ToFarsiWithTime())
                       .ToList() // اضافه شدن لیست ورودها
               });

            long administratorRoleId = Convert.ToInt64(RolesConst.Administrator); // مقدار نقش Administrator
            long stateRoleId = Convert.ToInt64(RolesConst.State); // مقدار نقش State

            // محاسبه تعداد کاربران با نقش‌های غیر از Administrator و State
            long excludedRoleCount = query.Count(x => x.RoleId != administratorRoleId && x.RoleId != stateRoleId);


            // فیلتر بر اساس نام کامل
            if (!string.IsNullOrWhiteSpace(searchModel.Fullname))
                query = query.Where(x => x.Fullname.Contains(searchModel.Fullname));

            // فیلتر بر اساس نام کاربری
            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
                query = query.Where(x => x.UserName.Contains(searchModel.UserName));

            // فیلتر بر اساس شماره موبایل
            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));

            // فیلتر بر اساس نقش
            if (searchModel.RoleId > 0)
                query = query.Where(x => x.RoleId == searchModel.RoleId);

            // فیلتر بر اساس دسته‌بندی استان
            if (searchModel.StateCategoryId > 0)
                query = query.Where(x => x.StateCategoryId == searchModel.StateCategoryId);

            // فیلتر محدودیت استان برای ادمین استانی
            if (provincialAdminStateCategoryId.HasValue)
                query = query.Where(x => x.StateCategoryId == provincialAdminStateCategoryId.Value);


            // تعداد کل رکوردها
            long totalCount = query.Count();

            // مرتب‌سازی لیست نهایی
            var result = query.OrderByDescending(x => x.Id).ToList();


            // افزودن تعداد کل به اولین آیتم
            if (result.Any())
            {
                result.First().TotalCount = totalCount;

                // اضافه کردن تعداد کاربران مستثنی به اولین رکورد
                result.First().ExcludedRoleCount = excludedRoleCount;
            }
            return result;
        }

        public List<AccountViewModel> SerachTotal(AccountSearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            var query = _context.Accounts
               .Include(x => x.Role)
               .Include(x => x.LoginAttempts) // اضافه کردن تاریخچه ورود
               .Select(x => new AccountViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   Fullname = x.Fullname,
                   Mobile = x.Mobile,
                   Role = x.Role.Name,
                   RoleId = x.RoleId,
                   StateCategoryId = x.StateCategoryId,
                   StatesCategory = x.StateCategory.Name,
                   UserName = x.UserName,
                   IsActive = x.IsActive,
                   Description = x.Description,
                   CreationDate = x.CreationDate.ToFarsiWithTime(),
                   LastLogin = x.LastLogin.ToFarsiWithTime(),
                   PreviousLogin = x.PreviousLogin.HasValue ? x.PreviousLogin.Value.ToFarsiWithTime() : "N/A",
                   LastLogins = x.LoginAttempts
                       .OrderByDescending(l => l.LoginTime)
                       .Take(20)
                       .Select(l => l.LoginTime.ToFarsiWithTime())
                       .ToList() // اضافه شدن لیست ورودها
               });



            query = query.Where(x =>
                (!string.IsNullOrWhiteSpace(searchModel.Fullname) && x.Fullname.Contains(searchModel.Fullname)) ||
                (!string.IsNullOrWhiteSpace(searchModel.UserName) && x.UserName.Contains(searchModel.UserName)) ||
                (!string.IsNullOrWhiteSpace(searchModel.Mobile) && x.Mobile.Contains(searchModel.Mobile))
            );

            // مرتب‌سازی لیست نهایی
            var result = query.OrderByDescending(x => x.Id).ToList();


           
            return result;
        }


        public bool ActiveUser(string activeCode)
        {
            var account =
                _context.Accounts.FirstOrDefault(x => x.IsActive == false );
            if (account != null)
            {
               account.ChangeActiveMode();

                _context.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }

        public List<Account> GetUsersByProvince(long stateId)
        {
            return _context.Accounts.Where(x => x.StateCategoryId == stateId).ToList();
        }

       
    }
}
