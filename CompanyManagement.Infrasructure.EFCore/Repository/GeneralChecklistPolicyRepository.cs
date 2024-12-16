using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.ChecklistAgg;
using Framework.Infrastructure;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
   

    public class GeneralChecklistPolicyRepository : RepositoryBase<long, GeneralPolicy>, IGeneralChecklistPolicyRepository
    {



        public GeneralChecklistPolicyRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }
        private readonly CompanyContext _companyContext;


        public EditCheckGenPol Getdetails(long id)
        {
            return _companyContext.GeneralPoliies.Select(x => new EditCheckGenPol()
            {
                Id = x.Id,
                // AccountIds = x.AccountId,
                //CompanyId = x.CompanyId ?? 0,
                //Description = x.Description,
                IsCompleted = x.IsCompleted,
                Name = "چک لیست عمومی-انتظامی",


            }).FirstOrDefault(x => x.Id == id);
        }

    }
}
