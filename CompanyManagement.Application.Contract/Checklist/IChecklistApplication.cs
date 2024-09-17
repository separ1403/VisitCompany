using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public  interface IChecklistApplication
    {
        OperationResult Create(CreateChecklist command);
        OperationResult CreateJuniper(CreateJuniperChecklist command);
        OperationResult CreateHPEDL380(CreateHPEDL380Checklist command);
        OperationResult CreateWin2019(CreateWin2019Checklist command);

        List<ChecklistViewModel> SerachByAccount(long accountId);

        OperationResult Edit(EditChecklist command, string sourcePage);
        OperationResult EditJunior(long id, long chekid);
        OperationResult EditHPEDL380(long id, long chekid);
        OperationResult EditWin2019(long id, long chekid);


        EditChecklist Getdetails(long id);
        List<ChecklistViewModel> Serach(ChecklistSearchModel searchModel);
        List<ChecklistViewModel> GetChecklists();
      //  public long GetLastCompanyId();
        List<ChecklistViewModel> GetAverageGeneralByCompany(ChecklistSearchModel searchModel);
        List<ChecklistViewModel> GetAverageGeneralByCompareCompany(ChecklistSearchModel2 searchModel);
        List<ChecklistViewModel> GetAverageProffesionalByCompany(ChecklistSearchModel searchModel);
    }
}
