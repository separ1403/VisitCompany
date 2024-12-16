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
  

    public class GeneralChecklistProffessionalRepository : RepositoryBase<long, GeneralProffesional>, IGeneralChecklistProffesionalRepository
    {



        public GeneralChecklistProffessionalRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }
        private readonly CompanyContext _companyContext;

        
        public EditCheckGenpro Getdetails(long id)
        {
            return _companyContext.GeneralProffesionals.Select(x => new EditCheckGenpro()
            {
                Id = x.Id,
                // AccountIds = x.AccountId,
                //CompanyId = x.CompanyId ?? 0,
                //Description = x.Description,
                IsCompleted = x.IsCompleted,
                Name = "چک لیست عمومی-فنی",


            }).FirstOrDefault(x => x.Id == id);
        }

    }
}
