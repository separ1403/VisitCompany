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
    public class HPEDL380Repository : RepositoryBase<long, HPEDL380>, IHPEDL380Repository
    {



        public HPEDL380Repository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }
        private readonly CompanyContext _companyContext;


        public EditHPEDL380Checklist Getdetails(long id)
        {
            return _companyContext.HPEDL380s.Select(x => new EditHPEDL380Checklist()
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
