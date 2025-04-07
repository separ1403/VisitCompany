using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;

namespace CompanyManagement.Application.Contract.Company
{
    public class CreateCompany
    {

        public string? CompanyName { get; set; }
        public string? Brand { get; set; }
        public string? ManagerName { get; set; }
        public string? SecurityManagerName { get; set; }
        public long CategoryId { get; set; }
        public List<long> LicenceIds { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }
        public string NationalCode { get; set; }
        public string Address { get; set; }
        public string? PostalCode { get; set; }

        public List<PersonDetail>? People { get; set; } = new List<PersonDetail>();
        public List<long>? PeopleIds { get; set; }
        public long? CountEmployees { get; set; }
        public long? CountFolowers { get; set; }

        public List<long>? AccountIds { get; set; } = new List<long>();
        public string Doamin { get; set; }
        public string? ReferDateFrom { get; set; }
        public string? ReferDateTo { get; set; }

        public string? ReferDate { get; set; }

        public string? CheckDate { get; set; }

        public long StateCategoryId { get; set; }
        //for ramio
        public string? TitleRasm { get; set; }

        public string? RegistrationDateRasm { get; set; }
        public string? RegistrationNoRasm { get; set; }
        public decimal? CapitalRasm { get; set; }
        public string? AddressRasm { get; set; }

        public string? TaxNumberRasm { get; set; }
        public string? PostalCodeRasm { get; set; }
        public string? LastUpdateRasm { get; set; }
        public string? StatusRasm { get; set; }
        public string? EdareKolRasm { get; set; }
        public string? VahedSabtiRasm { get; set; }

        
         
                                      
                                   
                             



    }
}