using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contracts.Account
{
    public class AccountViewModel
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string ProfilePhoto { get; set; }
        public string CreationDate { get; set; }
        public string LastLogin { get; set; }
        public string PreviousLogin { get; set; }
        public string CodeValidateMobile { get; set; }
        public bool IsActive { get; set; }
        public List<int> Permissions { get; set; } // فرض کنید Permissions یک لیست از رشته‌ها است

    }

}
