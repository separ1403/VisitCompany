namespace AccountManagement.Application.Contracts.Account
{
    public class AccountViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Fullname { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public long StateCategoryId { get; set; }
        public string StatesCategory { get; set; }

        public string ProfilePhoto { get; set; }
        public string CreationDate { get; set; }
        public string LastLogin { get; set; }
        public string PreviousLogin { get; set; }
        public string CodeValidateMobile { get; set; }
        public bool IsActive { get; set; }
        public List<int> Permissions { get; set; } // فرض کنید Permissions یک لیست از رشته‌ها است
        public List<string> LastLogins { get; set; } // اضافه شدن لیست ورودها
        public string Description { get; set; }
        public long TotalCount { get; set; }
        public long ExcludedRoleCount { get; set; }


        
    }

}
