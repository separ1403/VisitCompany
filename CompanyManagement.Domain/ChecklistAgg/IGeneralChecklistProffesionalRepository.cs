using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;
using Framework.Domain;

namespace CompanyManagement.Domain.ChecklistAgg
{
    
    public interface IGeneralChecklistProffesionalRepository : IRepository<long, GeneralProffesional>
    {
        EditCheckGenpro Getdetails(long id);

    }
}
