using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Domain.CompanyAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;
using AccountManagement.Application.Contracts.Account;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public  interface IChecklistRepository : IRepository<long, Checklist>
    {
      //  EditGeneralChecklist Getdetails(long id);
        List<ChecklistViewModel> Serach(ChecklistSearchModel searchModel, long? provincialAdminStateCategoryId = null);
        List<ChecklistViewModel> SerachTotal(ChecklistSearchModel searchModel, long? provincialAdminStateCategoryId = null);

        List<ChecklistViewModel> GetChecklists();
        List<ChecklistViewModel> SerachByAccount(long accountId);

        Checklist GetChecklistWithCompany(long id);
        Checklist GetChecklistWithAccount(long id);
     //   long GetLastCompanyId(); // متد جدید برای برگرداندن آخرین ID
        DateTime GetLastCompanyDate();
        //List<ChecklistViewModel> GetAverageGeneral();
        //List<ChecklistViewModel> GetAverageProffesional();

        List<ChecklistViewModel> GetAverageGeneralByCompany(ChecklistSearchModel searchModel);
        List<ChecklistViewModel> GetAverageGeneralByCompareCompany(ChecklistSearchModel2 searchModel);

        EditChecklist Getdetails(long id);

        List<ChecklistViewModel> GetAverageProffesionalByCompany(ChecklistSearchModel searchModel);
     
    }
}
