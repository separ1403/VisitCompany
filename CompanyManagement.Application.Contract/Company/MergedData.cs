using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Company
{
    public class MergedData
    {
        public string StateCategory { get; set; }
        public int ChecklistCount { get; set; }
        public int ChecklistCountOneWeek { get; set; }
        public int ChecklistCountOneMonth { get; set; }
        public int CompanyCount { get; set; }
        public int CompanyCountOneWeek { get; set; }
        public int CompanyCountOneMonth { get; set; }
    }
}
