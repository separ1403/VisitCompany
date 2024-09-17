using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Company
{
    public class CreateCompany
    {
        public string? CompanyName { get; set; }
        public string? Brand { get; set; }
        public string? ManagerName { get; set; }
        public string? SecurityManagerName { get; set; }
        public long CategoryId { get; set; }
        public long LicenceId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }
        public string NationalCode { get; set; }
        public List<long> AccountIds { get; set; }
    }
}