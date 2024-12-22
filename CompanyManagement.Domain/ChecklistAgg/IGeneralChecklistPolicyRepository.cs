using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;
using Framework.Domain;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public  interface  IGeneralChecklistPolicyRepository : IRepository<long, GeneralPolicy>
    {
        EditCheckGenPol Getdetails(long id);

    }
   
}
