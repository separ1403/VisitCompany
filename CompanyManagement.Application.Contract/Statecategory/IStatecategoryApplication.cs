using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Application.Contract.Company;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.StateCategory
{
    public  interface IStatecategoryApplication
    {
        OperationResult Create(CreateStateCategory command);
        OperationResult Edit(EditStateCategory command);
        EditStateCategory GetDetails(long id);
        List<StateCategoryViewModel> Search(StatecategorySearchModel searchModel);
        List<StateCategoryViewModel> GetStateCategories();
        List<StateCategoryViewModel> List();


    }
}
