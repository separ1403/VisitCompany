using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.RoleAgg;
using Framework.Application;
using Framework.Application.Sender.Sms;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using CompanyManagement.Domain.AccountAgg;
using Framework.Infrastructure;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher, IAuthHelper authHelper, IRoleRepository roleRepository, IHttpContextAccessor httpContextAccessor, ISmsSender smsSender)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
            _roleRepository = roleRepository;
            _httpContextAccessor = httpContextAccessor;
            _smsSender = smsSender;
        }


        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISmsSender _smsSender;







        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }

            if (_accountRepository.Exists(x => (x.UserName == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
                return operation;
            }



            account.Edit(command.Name,command.Fullname, command.Username, command.Mobile, command.RoleId,command.StateCategoryId,command.Description);
            _accountRepository.SaveChanges();
            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;


        }



        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();
            if (_accountRepository.Exists(x => x.UserName == command.Username /*|| x.Mobile == command.Mobile*/))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecord);
                return operation;
            }
            else
            {
                //var password = _passwordHasher.Hash(command.Password);

                var account = new Account(command.Name,command.Fullname, command.Username, /*password,*/ command.Mobile, command.RoleId,command.StateCategoryId,command.Description);

                //   _smsSender.SendByKavenagarAsync("کد فعالسازی شما در سایت لوازم خانگی حمید :  " + codevalidate , command.Mobile  );  // in r bayad badan faal konam alan be khatere sharj nabodan gheyre faale

                _accountRepository.Create(account);
                _accountRepository.SaveChanges();
                operation.Succeeded("ثبت نام با موفقیت انجام گردید");
                return operation;

            }
        }

        public OperationResult ChangePassword(ChangePassword command) // vorodi 2 ta meghdar migire bar asase model 
        //agar yeksan bodan onvaght be methide changepassword faght password ro ersal mikone
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }

            if (command.Password != command.RePassword)
            {
                operation.Failed(ApplicationMessages.PasswordNotMatch);
                return operation;
            }

            //var password = _passwordHasher.Hash(command.Password);
            //account.ChangePassword(password);
            _accountRepository.SaveChanges();
            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }

        public EditAccount Getdetails(long id)
        {
            return _accountRepository.Getdetails(id);
        }

        public ChangePassword Getdetail(long id)
        {
            return _accountRepository.Getdetail(id);
        }

        

        public AccountViewModel GetLastLogin(string searchModel)
        {
            return _accountRepository.GetLastLogin(searchModel);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.Username);

            if (account == null || account.Mobile != command.Mobile)
            {
                operation.Failed("نام کاربری یا شماره تلفن نادرست است.");
                return operation;
            }

            if (!account.IsActive)
            {
                operation.Failed("حساب کاربری شما فعال نیست.");
                return operation;
            }

            // ایجاد کد فعالسازی
           // var codevalidate = CodeGenerator.RandomNumber();
            var codevalidate = "11111";
            account.ChangeCodeValidateMobile(codevalidate);
            _accountRepository.SaveChanges();
          // _smsSender.SendByKavenagarAsync("کد فعالسازی شما: " + codevalidate, command.Mobile);

            return operation.Succeeded("کد فعالسازی ارسال شد.");
        }


        public void Logout()
        {
            _authHelper.Signout();
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public AccountViewModel GetAccountBy(long id)
        {
            var account = _accountRepository.Get(id);
            return new AccountViewModel()
            {
                Name = account.Name,
                Fullname = account.Fullname,
                Mobile = account.Mobile

            };
        }

        public bool ActiveUser(string activeCode)
        {
            return _accountRepository.ActiveUser(activeCode);
        }

        public AccountViewModel GetByMobile(string mobile)
        {
            var account = _accountRepository.GetByMobile(mobile);
            if (account == null) return null;

            // تبدیل Account به AccountViewModel
            return new AccountViewModel
            {
                Id = account.Id,
                UserName = account.UserName,
                Name = account.Name,
                Fullname = account.Fullname,
                Mobile = account.Mobile,
                RoleId = account.RoleId,
                //Role = account.Role.Name, // یا هر ویژگی‌ای که باید نمایش داده شود
                CreationDate = account.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"), // یا فرمت دلخواه
                // LastLogin = account.LastLogin.ToString("yyyy-MM-dd HH:mm:ss"),
                LastLogin = account.LastLogin.HasValue
                    ? account.LastLogin.Value.ToString("yyyy-MM-dd HH:mm:ss")
                    : "N/A",
                PreviousLogin = account.PreviousLogin?.ToString("yyyy-MM-dd HH:mm:ss"), // برای مقدار null-safe
                CodeValidateMobile = account.CodeValidateMobile,
                StateCategoryId = account.StateCategoryId,
                
            };

        }



        public void UpdateLastLogin(long accountId)
        {
          

            var account = _accountRepository.GetById(accountId);
            if (account != null)
            {
                 account.LastLoginCal();
                account.RecordLogin();

                _accountRepository.SaveChanges();
            }
        }

        public OperationResult DisableAccount(long id)
        {
            var account = _accountRepository.Get(id);
            if (account == null)
                return new OperationResult().Failed("کاربر یافت نشد");

            account.ChangeActiveMode(); // غیرفعال کردن کاربر
            _accountRepository.SaveChanges(); // ذخیره تغییرات

            return new OperationResult().Succeeded("کاربر با موفقیت غیرفعال شد");
        }

        public OperationResult EnableAccount(long id)
        {
            var account = _accountRepository.Get(id);
            if (account == null)
                return new OperationResult().Failed("کاربر یافت نشد");

            account.ChangeToActiveMode(); //رفعال کردن کاربر
            _accountRepository.SaveChanges(); // ذخیره تغییرات

            return new OperationResult().Succeeded("کاربر با موفقیت فعال شد");
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            return _accountRepository.Serach(searchModel, provincialAdminStateCategoryId); // مقدار درست ارسال می‌شود
        }

        public List<AccountViewModel> SearchTotal(AccountSearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            return _accountRepository.SerachTotal(searchModel, provincialAdminStateCategoryId); // مقدار درست ارسال می‌شود
        }
    }
}
