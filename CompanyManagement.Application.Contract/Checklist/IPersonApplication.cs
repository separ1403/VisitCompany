using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Company;
using Framework.Application;

namespace CompanyManagement.Application.Contract.Checklist
{
    public  interface IPersonApplication
    {
        List<PersonViewModel> SerachTotal(PersonSearchModel searchModel, long? provincialAdminStateCategoryId = null);
        OperationResult Create(CreatePeopleCompany command);


    }
}
