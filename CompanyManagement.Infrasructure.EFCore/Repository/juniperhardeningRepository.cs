using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.ChecklistAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Infrasructure.EFCore.Repository
{
    public class juniperhardeningRepository:RepositoryBase<long, JuniperHardening>, IjuniperhardeningRepository
    {



        public juniperhardeningRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext;
        }
        private readonly CompanyContext _companyContext;


        public EditJuniperChecklist Getdetails(long id)
        {
            return _companyContext.JuniperHardenings.Select(x => new EditJuniperChecklist()
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
