using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public class ChecklistSearchModel
    {
        public string? Name { get; set; }
        public string? NamePeopleCompany { get; set; }
        public string? Responsibility { get; set; }
        public string? PersonName { get; set;}
        public string? PersonResponsibility { get; set; }
        public string? PersonPhone { get; set; }
         
        public long? CompanyId { get;  set; }
        public long? AccountId { get;  set; }
        public int? TopCompaniesCount { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? UniqeCode { get; set; }
        public string? Brand { get; set; }
        public string? CompanyName { get; set; }
        public string? TypeCheckList { get; set; }
        public double? Average { get; set; }
        public string ScoreRange { get; set; } // بازه نمرات







    }
}

