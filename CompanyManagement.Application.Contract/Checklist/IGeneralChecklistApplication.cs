using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public interface IGeneralChecklistApplication
    {
        EditGeneralChecklist Getdetails(long id);
        List<(string PropertyName, long TotalScore)> GetMostVulnerableProperties();

    }
}
