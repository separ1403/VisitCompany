using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Company
{
    public class CompanyResponse
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? RegistrationNo { get; set; }
        public decimal? Capital { get; set; } // تغییر به nullable
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? TaxNumber { get; set; }
        public string? Status { get; set; }
        public string? EdareKol { get; set; }
        public string? VahedSabti { get; set; }
        public string? PictureUrl { get; set; }
        public string?  RegistrationDate { get; set; }
        public string? LastUpdate { get; set; }

    }



}
