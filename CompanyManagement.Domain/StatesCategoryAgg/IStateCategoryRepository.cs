using AccountManagement.Application.Contracts.Role;
using CompanyManagement.Application.Contract.CompanyCategory;
using CompanyManagement.Application.Contract.StateCategory;
using CompanyManagement.Domain.CompanyCategoryAgg;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.StatesCategoryAgg
{
 

    public interface IStateCategoryRepository : IRepository<long, StateCategory>
    {
        EditStateCategory GetDetails(long id);
        List<StateCategoryViewModel> Search(StatecategorySearchModel searchModel);

        List<StateCategoryViewModel> GetStateCategories();


        List<StateCategoryViewModel> List(long? provincialAdminStateCategoryId = null);

    }
}
