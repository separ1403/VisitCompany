using CompanyManagement.Domain.ChecklistAgg;
using Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
  

    public class GeneralChecklistRepository : RepositoryBase<long, GeneralChecklist>, IGeneralChecklistRepository
    {



        public GeneralChecklistRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }
        private readonly CompanyContext _companyContext;


      

        public EditGeneralChecklist Getdetails(long id)
        {
            return _companyContext.GeneralChecklists.Select(x => new EditGeneralChecklist()
            {
                Id = x.Id,
                // AccountIds = x.AccountId,
                //CompanyId = x.CompanyId ?? 0,
                //Description = x.Description,
                IsCompleted = x.IsCompleted,


            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
