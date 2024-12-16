using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Company
{
    public class BatchEditCompany
    {
        public List<long>? CompanyIds { get; set; } = new List<long>();// شناسه‌های شرکت‌های انتخاب‌شده
        public string? CompanyName { get; set; }
        public string? Brand { get; set; }
        public string? ManagerName { get; set; }
        public string? SecurityManagerName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }
        public string? NationalCode { get; set; }
        public string? Address { get; set; }
        public long CategoryId { get; set; }
        public List<long>? LicenceIds { get; set; } = new List<long>();
        public List<long>? AccountIds { get; set; }
        public string? Doamin { get; set; }
        public string? ReferDateFrom { get; set; }
        public string? ReferDateTo { get; set; }
        public string? CheckDate { get; set; }
        public long StateCategoryId { get; set; }

    }

}
