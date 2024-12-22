using AccountManagement.Domain.RoleAgg;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Domain.StatesCategoryAgg;
using Framework.Domain;

namespace CompanyManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string Name { get; private set; }

        public string Fullname { get; private set; }
        public string UserName { get; private set; }
       // public string Password { get; private set; }
        public string Mobile { get; private set; }
        public long RoleId { get; private set; }
        public bool IsActive { get; private set; }
        public Role Role { get; private set; }
        public StateCategory StateCategory { get; private set; }
        public long StateCategoryId { get; private set; }

        public DateTime? LastLogin { get; private set; } //in dige estefade nashod bekhatere lsiti az login ha
        public DateTime? PreviousLogin { get; private set; }//in dige estefade nashod bekhatere lsiti az login ha
        public string? CodeValidateMobile { get; private set; }  //be khatere errore SqlNullValueException: Data is Null. This method or property cannot be called on Null values.  ro midad ke search kardam goft ? inja bezaram va inke to table sql ham mishod ke null bashe

        public long ChecklistId { get; private set; }
        public List<Checklist> Checklists { get; private set; } = new List<Checklist>();
        public long CompanyId { get; private set; }

        public List<Company> Companies { get; private set; } // تغییر برای ارتباط Many-to-Many
        public List<LoginAttempt> LoginAttempts { get; private set; }
        public string? Description { get; private set; }



        public Account(string name,string fullname, string userName,/* string password,*/ string mobile, long roleId,long stateCategoryId, string description)
        {
            Name = name;
            Fullname = fullname;
            UserName = userName;
         //   Password = password;
            Mobile = mobile;
            RoleId = roleId;
            if (roleId == 0)
            {
                RoleId = 2; // 2 bod
            }

            LastLogin = null;
            IsActive = true;

            Companies = new List<Company>();
            StateCategoryId=stateCategoryId;

            LoginAttempts = new List<LoginAttempt>();
            Description = description;

        }

        public void Edit(string name,string fullname, string userName, string mobile, long roleId,long stateCategoryId, string description)
        {
            if (name != null)
                Name = name;
            if (fullname != null)
                Fullname = fullname;

            if (userName != null)
                UserName = userName;

            if (mobile != null)
                Mobile = mobile;

            if (roleId != 0)
                RoleId = roleId;

            if (stateCategoryId != 0)
                StateCategoryId = stateCategoryId;

            if (description != null)
                Description = description;

        }

        public void LastLoginCal() 
        {
            PreviousLogin = LastLogin; // ذخیره زمان ورود قبلی

            LastLogin = DateTime.Now;
        }


        public void RecordLogin()
        {
            var loginAttempt = new LoginAttempt(this.Id);
            LoginAttempts.Add(loginAttempt);
        }


        //public void ChangePassword(string password)
        //{
        //    Password = password;
        //}


        public void ChangeActiveMode()
        {
            IsActive = false;
        }

        public void ChangeToActiveMode()
        {
            IsActive = true;
        }

        public void ChangeCodeValidateMobile(string code)
        {
            CodeValidateMobile = code;
        }
        //public void AddChecklists(Checklist checklist)
        //{
        //    if (!Checklists.Contains(checklist))
        //    {
        //        Checklists.Add(checklist);
        //        checklist.Accounts.Add(this); // مقداردهی دوطرفه
        //    }
        //}

    }
}
