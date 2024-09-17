using CompanyManagement.Application.Contract.LicenceCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.LicenceCategory
{
    public class EditLicenceCategory : CreateLicenceCategory
    {
        public long Id { get; set; }
    }
}
