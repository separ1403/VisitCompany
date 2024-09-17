using CompanyManagement.Application.Contract.CompanyCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;
using CompanyManagement.Application.Contract.LicenceCategory;

namespace CompanyManagement.Domain.LicenceCategoryAgg
{
    public  interface ILicenceCategoryRepository : IRepository<long, LicenceCategory>
    {
        EditLicenceCategory GetDetails(long id);
        List<LicenceCategoryViewModel> Search(LicenceCategorySearchModel searchModel);

        List<LicenceCategoryViewModel> GetLicenceCategories();
       
    }
}
