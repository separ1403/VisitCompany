using AccountManagement.Domain.RoleAgg;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Domain.CompanyAgg;
using CompanyManagement.Domain.CompanyCategoryAgg;
using CompanyManagement.Domain.LicenceCategoryAgg;
using Framework.Application;
using Framework.Domain;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string Fullname { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public long RoleId { get; private set; }
        public bool IsActive { get; private set; }
        public Role Role { get; private set; }
        public DateTime LastLogin { get; private set; }
        public DateTime? PreviousLogin { get; private set; }
        public string? CodeValidateMobile { get; private set; }  //be khatere errore SqlNullValueException: Data is Null. This method or property cannot be called on Null values.  ro midad ke search kardam goft ? inja bezaram va inke to table sql ham mishod ke null bashe

        public long ChecklistId { get; private set; }
        public List<Checklist> Checklists { get; private set; }
        public long CompanyId { get; private set; }

        public List<Company> Companies { get; private set; } // تغییر برای ارتباط Many-to-Many



        public Account(string fullname, string userName, string password, string mobile, long roleId)
        {
            Fullname = fullname;
            UserName = userName;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;
            if (roleId == 0)
            {
                RoleId = 2; // 2 bod
            }

            IsActive = true;

            Companies = new List<Company>();


        }

        public void Edit(string fullname, string userName, string mobile, long roleId)
        {
            if (fullname != null)
                Fullname = fullname;

            if (userName != null)
                UserName = userName;

            if (mobile != null)
                Mobile = mobile;

            if (roleId != 0)
                RoleId = roleId;



        }

        public void LastLoginCal()
        {
            PreviousLogin = LastLogin; // ذخیره زمان ورود قبلی

            LastLogin = DateTime.Now;
        }


        public void ChangePassword(string password)
        {
            Password = password;
        }


        public void ChangeActiveMode()
        {
            IsActive = true;
        }

        public void ChangeCodeValidateMobile(string code)
        {
            CodeValidateMobile = code;
        }

    }
}
