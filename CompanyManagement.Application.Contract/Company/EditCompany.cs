using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Company
{
    public  class EditCompany:CreateCompany
    {
        public long Id { get; set; }
    }
}
