using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.CompanyCategory
{
    public class EditCompanyCategory : CreateCompanyCategory
    {
        public long Id { get; set; }
    }
}
