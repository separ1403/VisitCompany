using CompanyManagement.Application.Contract.Checklist;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public interface IPersonRepository : IRepository<long, Person>
    {
        List<PersonViewModel> SerachTotal(PersonSearchModel searchModel, long? provincialAdminStateCategoryId = null);

    }
}
