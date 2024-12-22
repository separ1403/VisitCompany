using CompanyManagement.Application.Contract.Checklist;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public  interface  IGeneralChecklistRepository : IRepository<long, GeneralChecklist>
    {
        EditGeneralChecklist Getdetails(long id);
        List<(string PropertyName, long TotalScore)> GetMostVulnerableProperties();

    }

}
