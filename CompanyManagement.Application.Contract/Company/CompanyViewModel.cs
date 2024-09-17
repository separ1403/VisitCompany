using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Company
{
    public class CompanyViewModel
    {
        public long Id { get; set; }
        public string CompanyName { get;  set; }
        public string Brand { get;  set; }
        public string ManagerName { get;  set; }
        public string SecurityManagerName { get;  set; }
        public string PhoneNumber { get;  set; }
        public string Description { get;  set; }
        public string NationalCode { get;  set; }
        public bool IsActive { get;  set; }
        public string Category { get; set; }
        public double Average { get;  set; }

        public long CategoryId { get; set; }
        public  long LicenceId { get; set; }
        public string CompanyCreateDate { get;  set; }
        public List<long>? AccountIds { get; set; } // باید مقداردهی شود
        public string CheckByAccount { get; set; }

    }
}
