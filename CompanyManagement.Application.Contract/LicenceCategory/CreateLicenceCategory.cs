using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace CompanyManagement.Application.Contract.LicenceCategory
{
    public  class CreateLicenceCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Refrence { get; set; }
        public bool Status { get;  set; }
        public string? Fullname { get;  set; }
        public string? CompanyName { get;  set; }


    }
}
