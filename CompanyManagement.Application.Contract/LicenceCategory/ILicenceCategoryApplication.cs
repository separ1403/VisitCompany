using CompanyManagement.Application.Contract.Company;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.LicenceCategory
{
    public  interface ILicenceCategoryApplication
    {
        OperationResult Create(CreateLicenceCategory command);
        OperationResult Edit(EditLicenceCategory command);
        EditLicenceCategory GetDetails(long id);
        List<LicenceCategoryViewModel> Search(LicenceCategorySearchModel searchModel);
        List<LicenceCategoryViewModel> GetLicenceCategories();


    }
}
