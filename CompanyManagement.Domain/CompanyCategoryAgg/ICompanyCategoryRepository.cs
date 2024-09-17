using CompanyManagement.Application.Contract.CompanyCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace CompanyManagement.Domain.CompanyCategoryAgg
{
    public  interface ICompanyCategoryRepository : IRepository<long, CompanyCategory>
    {
        EditCompanyCategory GetDetails(long id);
        List<CompanyCategoryViewModel> Search(CompanyCategorySearchModel searchModel);

        List<CompanyCategoryViewModel> GetCompanyCategories();
       
    }
}
