using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public class EditGeneralChecklist:CreateGeneralChecklist
    {
        public long Id { get; set; }
    }
}
