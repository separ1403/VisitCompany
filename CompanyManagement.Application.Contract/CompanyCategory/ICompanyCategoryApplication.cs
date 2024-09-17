using CompanyManagement.Application.Contract.Company;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.CompanyCategory
{
    public  interface ICompanyCategoryApplication
    {
        OperationResult Create(CreateCompanyCategory command);
        OperationResult Edit(EditCompanyCategory command);
        EditCompanyCategory GetDetails(long id);
        List<CompanyCategoryViewModel> Search(CompanyCategorySearchModel searchModel);
        List<CompanyCategoryViewModel> GetCompanyCategories();

    }
}
