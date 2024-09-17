using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public class ChecklistSearchModel2
    {
        public string? Name { get; set; }
        public long? CompanyId { get; set; }
        public long? AccountId { get; set; }
        public int? TopCompaniesCount { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}
