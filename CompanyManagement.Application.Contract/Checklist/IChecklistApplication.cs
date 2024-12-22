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
        OperationResult CreateGeneralChecklist(CreateGeneralChecklist command);
        OperationResult CreateGeneralChecklistProfff(CreateCheckGenpro command);
        OperationResult CreateGeneralChecklistPol(CreateCheckGenPol command);



        List<ChecklistViewModel> SerachByAccount(long accountId);

      //  OperationResult Edit(EditGeneralChecklist command, string sourcePage);
        OperationResult EditJunior(long id, long chekid);
        OperationResult EditHPEDL380(long id, long chekid);
        OperationResult EditWin2019(long id, long chekid);
        OperationResult EditGeneralChecklist(long id, long chekid);
        OperationResult EditGeneralChecklistProff(long id, long chekid);
        OperationResult EditGeneralChecklistPol(long id, long chekid);


        EditChecklist Getdetails(long id);

        EditGeneralChecklist GetdetailsGeneralChecklist(long id);
        EditHPEDL380Checklist GetdetailsHPEDL380Checklist(long id);
        EditJuniperChecklist GetdetailsJuniperChecklist(long id);
        EditWin2019Checklist GetdetailsWin2019Checklist(long id);
        EditCheckGenpro GetdetailsGeneralChecklistProff(long id);
        EditCheckGenPol GetdetailsGeneralChecklistPol(long id);





        // EditGeneralChecklist Getdetails(long id);
        List<ChecklistViewModel> Serach(ChecklistSearchModel searchModel, long? provincialAdminStateCategoryId = null);
        List<ChecklistViewModel> GetChecklists();
        List<ChecklistViewModel> SerachTotal(ChecklistSearchModel searchModel, long? provincialAdminStateCategoryId = null);

        List<ChecklistViewModel> GetAverageGeneralByCompany(ChecklistSearchModel searchModel);
        List<ChecklistViewModel> GetAverageGeneralByCompareCompany(ChecklistSearchModel2 searchModel);
        List<ChecklistViewModel> GetAverageProffesionalByCompany(ChecklistSearchModel searchModel);
        public bool Exists(string uniqueCode);

    }
}
