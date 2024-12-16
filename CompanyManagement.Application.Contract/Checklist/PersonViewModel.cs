using AccountManagement.Application.Contracts.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public class PersonViewModel
    {
        public long Id { get; set; }
        public string CompanyBrand { get; set; }
        public string CompanyName { get; set; }
        public string NamePeopleCo { get; set; }
        public string RspponsePeopleCo { get; set; }
        public string PhonePeopleCo { get; set; }
        public List<AccountViewModel> Accounts { get; set; } = new List<AccountViewModel>(); // تعریف لیست حساب‌ها
    }
}
